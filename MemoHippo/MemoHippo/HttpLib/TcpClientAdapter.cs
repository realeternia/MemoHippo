using System.IO;
using System.Net;
using System.Net.Sockets;

namespace HttpLib.Clients
{
    public class TcpClientAdapter
    {
        private readonly TcpClient _client;

        public TcpClientAdapter(TcpClient client)
        {
            _client = client;
        }

        public Stream Stream
        {
            get { return _client.GetStream(); }
        }

        public bool Connected
        {
            get { return _client.Connected; }
        }

        public void Close()
        {
            _client.Close();
        }


        public EndPoint RemoteEndPoint
        {
            get { return _client.Client.RemoteEndPoint; }
        }
    }
}