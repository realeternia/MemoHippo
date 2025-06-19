using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace MemoHippo.Utils
{
    public class ConfigInfo
    {
        public string ApiKey { get; set; }
    }

    internal class ConfigLoader
    {
        public static ConfigInfo Instance { get; private set; }

        static ConfigLoader()
        {
            var yaml = File.ReadAllText("./config.yaml", Encoding.UTF8);

            var deserializer = new DeserializerBuilder().Build();
            Instance = deserializer.Deserialize<ConfigInfo>(yaml);
        }
    }
}
