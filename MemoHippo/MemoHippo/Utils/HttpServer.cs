using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoHippo.Utils
{
    class HttpServer
    {
        public static void Run()
        {
            Thread thread = new Thread(DoRun);
            thread.IsBackground = true;
            thread.Start();
        }

        private static void DoRun()
        {
            HttpListener listener = new HttpListener();

            // 设置监听的URL前缀
            try
            {
                listener.Prefixes.Add("http://172.30.44.13:8081/");
                listener.Start();
            }
            catch
            {
                return;
            }

            while (true)
            {
                // 等待请求连接
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                // 获取请求的URL路径
                string path = request.Url.AbsolutePath;

                // 根据不同的路径返回不同的响应
                string responseString;
                switch (path)
                {
                    case "/":
                        responseString = "<html><body>Welcome to the home page!</body></html>";
                        break;
                    case "/hello":
                        responseString = "<html><body>Hello, World!</body></html>";
                        break;
                    case "/file":
                        NameValueCollection query = request.QueryString;
                        string name = query["id"] ?? "0";
                        var itemId = int.Parse(name);
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
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseString = "<html><body>404 - Not Found</body></html>";
                        break;
                }

                // 将响应字符串转换为字节数组
                byte[] buffer = Encoding.Default.GetBytes(responseString);

                // 设置响应内容的长度
                response.ContentLength64 = buffer.Length;

                // 将响应内容写入输出流
                response.OutputStream.Write(buffer, 0, buffer.Length);

                // 关闭输出流
                response.OutputStream.Close();
            }
        }
    }
}
