using System;
using System.Text;
using System.Threading.Tasks;
using MemoHippo.Utils;

namespace HttpLib.Handlers
{
    public class ExceptionHandler : IHttpRequestHandler
    {
        private bool showClient;
        public static int Count;

        public ExceptionHandler(bool showToClient)
        {
            showClient = showToClient;
        }

        public async Task Handle(HttpContext context, Func<Task> next)
        {
            try
            {
                await next().ConfigureAwait(false);
            }
            catch (HttpException e)
            {
                HLog.Error(context.Request.Uri + " ExceptionHandler " + Encoding.UTF8.GetString(context.Request.Post.Raw) + e);
                if (showClient)
                {
                    context.Response = new HttpResponse(e.ResponseCode, "Error while handling your request. " + e.Message, false);
                }
                else
                {
                    context.Response = new HttpResponse(e.ResponseCode, "Internal server error 500", false);
                }

                Count++;
            }
            catch (Exception e)
            {
                HLog.Error(context.Request.Uri + " ExceptionHandler2 " + Encoding.UTF8.GetString(context.Request.Post.Raw) + e);
                if (showClient)
                {
                    context.Response = new HttpResponse(HttpResponseCode.InternalServerError, "Error while handling your request. " + e.Message, false);
                }
                else
                {
                    context.Response = new HttpResponse(HttpResponseCode.InternalServerError, "Internal server error 500", false);
                }
                Count++;
            }
        }
    }
    public class HttpException : Exception
    {
        private readonly HttpResponseCode _responseCode;

        public HttpResponseCode ResponseCode
        {
            get { return _responseCode; }
        }

        public HttpException(HttpResponseCode responseCode)
        {
            _responseCode = responseCode;
        }
        public HttpException(HttpResponseCode responseCode, string message) : base(message)
        {
            _responseCode = responseCode;
        }
    }
}