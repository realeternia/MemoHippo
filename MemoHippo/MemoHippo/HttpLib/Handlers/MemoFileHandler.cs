using System;
using System.Threading.Tasks;
using HttpLib;
using HttpLib.Headers;
using MemoHippo;
using MemoHippo.Utils;
using RtfPipe;

namespace HttpLib.Handlers
{
    public class MemoFileHandler : IHttpRequestHandler
    {
        public Task Handle(HttpContext context, Func<Task> next)
        {
            context.Request.QueryString.TryGetByName("id", out var id);

            string responseString;
            var itemId = int.Parse(id);
            var itemInfo = MemoBook.Instance.GetItem(itemId);
            if (itemInfo == null || !itemInfo.HasTag("share"))
            {
                responseString = "<html><body>Hello, World!</body></html>";
            }
            else
            {
               var htm = Rtf.ToHtml(new RtfSource(RtfModifier.ReadRtf(itemId)));
                htm = htm.Replace("top:40px", "top:-4px").Replace("top:24px", "top:-4px");
                responseString = "<html><body style=\"background-color: black; color: white;\">" + htm + "</body><html>";
            }

            context.Response = new HttpResponse(HttpResponseCode.Ok, responseString, context.Request.Headers.KeepAliveConnection());

            return Task.Factory.GetCompleted();
        }
    }
}