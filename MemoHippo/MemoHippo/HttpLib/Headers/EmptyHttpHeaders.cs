using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace HttpLib.Headers
{
    [DebuggerDisplay("Empty Headers")]
    public class EmptyHttpHeaders : IHttpHeaders
    {
        public static readonly IHttpHeaders Empty = new EmptyHttpHeaders();
        
        private static readonly IEnumerable<KeyValuePair<string, string>> EmptyKeyValuePairs = new KeyValuePair<string, string>[0];

        private EmptyHttpHeaders()
        {

        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return EmptyKeyValuePairs.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return EmptyKeyValuePairs.GetEnumerator();
        }
        public string GetByName(string name)
        {
            throw new ArgumentException("EmptyHttpHeaders does not contain any header");
        }
        public bool TryGetByName(string name, out string value)
        {
            value = null;
            return false;
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
    }
}