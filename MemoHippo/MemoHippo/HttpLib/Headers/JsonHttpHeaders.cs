using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using MemoHippo.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpLib.Headers
{
    [DebuggerDisplay("{Count} Query String Headers")]
    internal class JsonHttpHeaders : IHttpHeaders
    {
        private readonly HttpHeaders _child;

        private readonly int _count;

        public JsonHttpHeaders(string query)
        {
            try
            {
                var jToken = JToken.Parse(query);
                var values = new Dictionary<string, string>();
                foreach (var pair in jToken.Children())
                {
                    values[pair.Path] = pair.Last.Value<string>();
                }
                _count = values.Count;
                _child = new HttpHeaders(values);
            }
            catch (Exception exception)
            {
                HLog.Warn("JsonHttpHeaders init error " + exception + " len="+ query.Length);
            }
        }

        public string GetByName(string name)
        {
            return _child.GetByName(name);
        }
        public bool TryGetByName(string name, out string value)
        {
            return _child.TryGetByName(name, out value);
        }
        public Dictionary<string, string> GetManyByName(List<string> names)
        {
            Dictionary<string, string> results = new Dictionary<string, string>();
            foreach (var name in names)
            {
                bool success = TryGetByName(name, out string value);
                if (success)
                {
                    results[name] = value;
                }
                else
                {
                    results[name] = "null";
                }
            }

            return results;
        }
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _child.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal int Count
        {
            get
            {
                return _count;
            }
        }
    }
}