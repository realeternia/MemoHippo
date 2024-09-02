using System;
using System.Threading.Tasks;
using HttpLib;
using HttpLib.Headers;
using MemoHippo;
using MemoHippo.Utils;

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
                var text = RtfModifier.ReadRtfPlainText(itemId);
                text = text.Replace("\n", "<br/>");
                text = text.Replace("●", "&nbsp;&nbsp;●");
                text = text.Replace("◆", "&nbsp;&nbsp;&nbsp;&nbsp;◆");
                text = text.Replace("◇", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;◇");
                responseString = "<html><body><p style=\"font-size: 120%;\">" + text + "</p></body></html>";
            }

            context.Response = new HttpResponse(HttpResponseCode.Ok, responseString, context.Request.Headers.KeepAliveConnection());

            return Task.Factory.GetCompleted();
        }
    }
}