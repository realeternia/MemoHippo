using System.Net.Sockets;
using System.Threading.Tasks;
using HttpLib.Clients;

namespace HttpLib.Listeners
{
    public class TcpListenerAdapter
    {
        private readonly TcpListener _listener;

        public TcpListenerAdapter(TcpListener listener)
        {
            _listener = listener;
            _listener.Start();
        }
        public async Task<TcpClientAdapter> GetClient()
        {
            return new TcpClientAdapter(await _listener.AcceptTcpClientAsync().ConfigureAwait(false));
        }

        public void Dispose()
        {
            _listener.Stop();
        }
    }
}