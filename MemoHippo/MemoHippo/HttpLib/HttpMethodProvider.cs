using System;

namespace HttpLib
{
    public class HttpMethodProvider : IHttpMethodProvider
    {
        public static readonly IHttpMethodProvider Default = new HttpMethodProviderCache(new HttpMethodProvider());

        public HttpMethodProvider()
        {
            
        }

        public HttpMethods Provide(string name)
        {
            var capitalName = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            return (HttpMethods)Enum.Parse(typeof(HttpMethods), capitalName);
        }
    }
}