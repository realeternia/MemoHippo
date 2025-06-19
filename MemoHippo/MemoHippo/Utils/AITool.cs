using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MemoHippo.Utils
{
    internal class AITool
    {
        public class StreamChatResponse
        {
            public Choice[] choices { get; set; }
            public class Choice
            {
                public Delta delta { get; set; }
            }
            public class Delta
            {
                public string content { get; set; }
            }
        }

        public static async Task CallDeepSeekApi(string context, Action<string> onStreamReceived = null)
        {
            string apiKey = ConfigLoader.Instance.ApiKey;
            string apiUrl = "https://api.deepseek.com/v1/chat/completions";

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var requestData = new
            {
                model = "deepseek-chat",
                messages = new[]
                {
            new { role = "user", content = context }
        },
                stream = true,
                temperature = 0.7,
            };

            string jsonData1 = JsonConvert.SerializeObject(requestData);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var httpContent = new StringContent(jsonData1, Encoding.UTF8, "application/json");

                using (var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = httpContent
                })
                using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        // 处理事件流格式
                        if (line.StartsWith("data: "))
                        {
                            var jsonData = line.Substring(6).Trim();
                            if (jsonData == "[DONE]") break;

                            var chunk = JsonConvert.DeserializeObject<StreamChatResponse>(jsonData);
                            var content = chunk?.choices?.FirstOrDefault()?.delta?.content;

                            if (!string.IsNullOrEmpty(content))
                            {
                                if (onStreamReceived != null)
                                    onStreamReceived(content);
                                // 若需要模拟逐字效果，可添加延迟
                                await Task.Delay(50);
                            }
                        }
                    }
                }
            }
            }
    }
}
