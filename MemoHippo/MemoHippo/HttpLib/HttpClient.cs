/*
 * Copyright (C) 2011 uhttpsharp project - http://github.com/raistlinthewiz/uhttpsharp
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.

 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.

 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System.Text;
using log4net;
using System.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HttpLib.Clients;
using HttpLib.RequestProviders;
using HttpLib.Headers;
using MemoHippo.Utils;

namespace HttpLib
{
    internal sealed class HttpClientHandler
    {
        private const string CrLf = "\r\n";
        private static readonly byte[] CrLfBuffer = Encoding.UTF8.GetBytes(CrLf);

        private readonly TcpClientAdapter _client;
        private readonly Func<HttpContext, Task> _requestHandler;
        private readonly HttpRequestProvider _requestProvider;
        private readonly EndPoint _remoteEndPoint;
        private readonly Stream _stream;

        private int _serverPort;
        private int _clientReadLimit;
        private int _clientWriteLimit;

        public HttpClientHandler(TcpClientAdapter client, Func<HttpContext, Task> requestHandler, HttpRequestProvider requestProvider, int serverPort1, int readLimit, int writeLimit)
        {
            _remoteEndPoint = client.RemoteEndPoint;
            _client = client;
            _requestHandler = requestHandler;
            _requestProvider = requestProvider;
            _serverPort = serverPort1;
            _clientReadLimit = readLimit;
            _clientWriteLimit = writeLimit;

            //_stream = new BufferedStream(_client.Stream, 8192);
            _stream = _client.Stream;

            if (!_remoteEndPoint.ToString().StartsWith("127.0"))
                HLog.Debug("Got Client {0} @{1}", _remoteEndPoint, serverPort1);

            Task.Factory.StartNew(Process);
        }

        private async void Process()
        {
            try
            {
                while (_client.Connected)
                {
                    // TODO : Configuration.
                    var limitedStream = new NotFlushingStream(new LimitedStream(_stream, _clientReadLimit, _clientWriteLimit));
                    var streamReader = new StreamReader(limitedStream);
                    
                    var request = await _requestProvider.Provide(streamReader).ConfigureAwait(false);

                    if (request != null)
                    {
                        var context = new HttpContext(request, _client.RemoteEndPoint);

                        await _requestHandler(context).ConfigureAwait(false);

                        if (context.Response != null)
                        {
                            var streamWriter = new StreamWriter(limitedStream) { AutoFlush = false };
                            
                            await WriteResponse(context, streamWriter).ConfigureAwait(false);
                            await limitedStream.ExplicitFlushAsync().ConfigureAwait(false);

                            if (!request.Headers.KeepAliveConnection() || context.Response.CloseConnection)
                            {
                                _client.Close();
                            }
                        }
                    }
                    else
                    {
                        _client.Close();
                    }
                }
            }
            catch (Exception e)
            {
                // Hate people who make bad calls.
                HLog.Warn("Error while serving : {0} {1}", _remoteEndPoint, e.Message);
                _client.Close();
            }

            if (!_remoteEndPoint.ToString().StartsWith("127.0"))
                HLog.Debug("Lost Client {0}", _remoteEndPoint);
        }
        private async Task WriteResponse(HttpContext context, StreamWriter writer)
        {
            try
            {
                IHttpResponse response = context.Response;
                IHttpRequest request = context.Request;

                // Headers
                await writer.WriteLineAsync(string.Format("HTTP/1.1 {0} {1}",
                        (int)response.ResponseCode,
                        response.ResponseCode))
                    .ConfigureAwait(false);

                foreach (var header in response.Headers)
                {
                    await writer.WriteLineAsync(string.Format("{0}: {1}", header.Key, header.Value)).ConfigureAwait(false);
                }

                // Empty Line
                await writer.WriteLineAsync().ConfigureAwait(false);
                // 这一步，如果不flush，会产生先输出body，在输出header的情况
                await writer.FlushAsync().ConfigureAwait(false);
                // Body
                await response.WriteBody(writer).ConfigureAwait(false);
                await writer.FlushAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                // Hate people who make bad calls.
                HLog.Warn("Error while writing : {0} {1}", _remoteEndPoint, e);
                _client.Close();
            }
        }

    }

    internal class NotFlushingStream : Stream
    {
        private readonly Stream _child;
        public NotFlushingStream(Stream child)
        {
            _child = child;
        }


        public void ExplicitFlush()
        {
            _child.Flush();
        }

        public Task ExplicitFlushAsync()
        {
            return _child.FlushAsync();
        }

        public override void Flush()
        {
            // _child.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _child.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _child.SetLength(value);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _child.Read(buffer, offset, count);
        }

        public override int ReadByte()
        {
            return _child.ReadByte();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _child.Write(buffer, offset, count);
        }
        public override void WriteByte(byte value)
        {
            _child.WriteByte(value);
        }
        public override bool CanRead
        {
            get { return _child.CanRead; }
        }
        public override bool CanSeek
        {
            get { return _child.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return _child.CanWrite; }
        }
        public override long Length
        {
            get { return _child.Length; }
        }
        public override long Position
        {
            get { return _child.Position; }
            set { _child.Position = value; }
        }
        public override int ReadTimeout
        {
            get { return _child.ReadTimeout; }
            set { _child.ReadTimeout = value; }
        }
        public override int WriteTimeout
        {
            get { return _child.WriteTimeout; }
            set { _child.WriteTimeout = value; }
        }
    }

    public static class RequestHandlersAggregateExtensions
    {

        public static Func<HttpContext, Task> Aggregate(this IList<IHttpRequestHandler> handlers)
        {
            return handlers.Aggregate(0);
        }

        private static Func<HttpContext, Task> Aggregate(this IList<IHttpRequestHandler> handlers, int index)
        {
            if (index == handlers.Count)
            {
                return null;
            }

            var currentHandler = handlers[index];
            var nextHandler = handlers.Aggregate(index + 1);
            
            return context => currentHandler.Handle(context, () => nextHandler(context));
        }


    }
}