using System.Dynamic;
using System.Net;

namespace HttpLib
{
    public class HttpContext
    {
        private readonly IHttpRequest _request;
        private readonly EndPoint _remoteEndPoint;
        public HttpContext(IHttpRequest request, EndPoint remoteEndPoint)
        {
            _request = request;
            _remoteEndPoint = remoteEndPoint;
        }

        public IHttpRequest Request
        {
            get { return _request; }
        }

        public IHttpResponse Response { get; set; }

        public EndPoint RemoteEndPoint
        {
            get { return _remoteEndPoint; }
        }
    }
}