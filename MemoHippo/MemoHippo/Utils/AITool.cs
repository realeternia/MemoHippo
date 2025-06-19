using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public class AiResponseModel
        {
            public List<Choice> Choices { get; set; }

            public class Choice
            {
                public Message Message { get; set; }

                public string Content => Message?.Content;
            }

            public class Message
            {
                public string Role { get; set; }
                public string Content { get; set; }
            }
        }

        public static async Task<string> CallDeepSeekApi(string context)
        {
            string apiKey = ConfigLoader.Instance.ApiKey;
            string apiUrl = "https://api.deepseek.com/v1/chat/completions"; // 假设的 API 地址

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // 请求数据
            var requestData = new
            {
                model = "deepseek-chat",
                messages = new []
                {
                 //   new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = context }
                },
                stream = false,
                temperature = 0.7,
            };

            // 序列化请求数据
            string jsonData = JsonConvert.SerializeObject(requestData);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // 检查响应状态
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    // 解析 JSON 响应
                    var aiResponse = JsonConvert.DeserializeObject<AiResponseModel>(result);

                    // 提取第一个回复内容
                    return aiResponse.Choices?.FirstOrDefault()?.Content ?? "无法提取回答内容";
                }
                else
                {
                    throw new Exception($"API 调用失败: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
        }
    }
}
