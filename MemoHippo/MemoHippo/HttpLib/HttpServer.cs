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

using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using HttpLib.Listeners;
using HttpLib.RequestProviders;
using MemoHippo.Utils;

namespace HttpLib
{
    public class HttpServer : IDisposable
    {
        private bool _isActive;
        private int _port;
        private int _clientReadLimit;
        private int _clientWriteLimit;

        private readonly IList<IHttpRequestHandler> _handlers = new List<IHttpRequestHandler>();
        private readonly IList<TcpListenerAdapter> _listeners = new List<TcpListenerAdapter>();
        private readonly HttpRequestProvider _requestProvider;


        public HttpServer(HttpRequestProvider requestProvider, int port1, int clientReadLimit, int clientWriteLimit)
        {
            _requestProvider = requestProvider;
            _port = port1;
            _clientReadLimit = clientReadLimit;
            _clientWriteLimit = clientWriteLimit;

            HLog.Debug("HttpServer inited @" + port1);
        }

        public void Use(IHttpRequestHandler handler)
        {
            _handlers.Add(handler);
        }

        public void Use(TcpListenerAdapter listener)
        {
            _listeners.Add(listener);
        }

        public void Start()
        {
            _isActive = true;

            foreach (var listener in _listeners)
            {
                var tempListener = listener;

                Task.Factory.StartNew(() => Listen(tempListener));
            }

            HLog.Info("Embedded httpserver started @" + _port);
        }

        private async void Listen(TcpListenerAdapter listener)
        {
            var aggregatedHandler = _handlers.Aggregate();

            while (_isActive)
            {
                try
                {
                    new HttpClientHandler(await listener.GetClient().ConfigureAwait(false), aggregatedHandler, _requestProvider, _port, _clientReadLimit, _clientWriteLimit);
                }
                catch (Exception e)
                {
                    HLog.Warn("Error while getting client " + e);
                }
            }

            HLog.Info("Embedded httpserver stopped.");
        }

        public void Dispose()
        {
            _isActive = false;
        }
    }
}