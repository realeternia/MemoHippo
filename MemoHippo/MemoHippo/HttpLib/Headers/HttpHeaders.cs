using MemoHippo.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLib.Headers
{
    internal class EmptyHttpPost : IHttpPost
    {
        private static readonly byte[] _emptyBytes = new byte[0];

        public static readonly IHttpPost Empty = new EmptyHttpPost();

        private EmptyHttpPost()
        {

        }

        #region IHttpPost implementation

        public byte[] Raw
        {
            get
            {
                return _emptyBytes;
            }
        }

        public IHttpHeaders Parsed
        {
            get
            {
                return EmptyHttpHeaders.Empty;
            }
        }

        #endregion
    }

    internal class HttpPost : IHttpPost
    {
        public static async Task<IHttpPost> Create(StreamReader reader, int postContentLength)
        {
            char[] rawEncoded = new char[postContentLength];
            int readTotal = 0;
            byte[] raw = null;

            DateTime nowTime = DateTime.Now;

            while (true)
            {
                int readBytes = await reader.ReadAsync(rawEncoded, readTotal, postContentLength - readTotal).ConfigureAwait(false);
                readTotal += readBytes;

                raw = Encoding.UTF8.GetBytes(rawEncoded, 0, readTotal);

                if (postContentLength == raw.Length || readBytes == 0)
                    break;

                if ((DateTime.Now - nowTime).TotalSeconds >= 5)
                {
                    HLog.Warn(string.Format("HttpPost timeout total={0} rd={1} now={2}", postContentLength, readTotal, raw.Length));
                    break;
                }

                HLog.Info(string.Format("HttpPost total={0} rd={1} now={2}", postContentLength, readTotal, raw.Length));
            }
            
            return new HttpPost(raw, readTotal);
        }

        private readonly int _readBytes;

        private readonly byte[] _raw;

        private readonly Lazy<IHttpHeaders> _parsed;

        public HttpPost(byte[] raw, int readBytes)
        {
            _raw = raw;
            _readBytes = readBytes;
            _parsed = new Lazy<IHttpHeaders>(Parse);
        }

        private IHttpHeaders Parse()
        {
            string body = Encoding.UTF8.GetString(_raw, 0, _raw.Length);
            var parsed = new JsonHttpHeaders(body);
           
            return parsed;
        }

        #region IHttpPost implementation

        public byte[] Raw
        {
            get
            {
                return _raw;
            }
        }

        public IHttpHeaders Parsed
        {
            get
            {
                return _parsed.Value;
            }
        }

        #endregion


    }

    [DebuggerDisplay("{Count} Headers")]
    public class ListHttpHeaders : IHttpHeaders
    {
        private readonly IList<KeyValuePair<string, string>> _values;
        public ListHttpHeaders(IList<KeyValuePair<string, string>> values)
        {
            _values = values;
        }

        public string GetByName(string name)
        {
            return _values.Where(kvp => kvp.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Select(kvp => kvp.Value).First();
        }

        public bool TryGetByName(string name, out string value)
        {
            value = _values.Where(kvp => kvp.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Select(kvp => kvp.Value).FirstOrDefault();

            return (value != default(string));
        }
        public Dictionary<string, string> GetManyByName(List<string> names)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal int Count
        {
            get
            {
                return _values.Count;
            }
        }
    }


    [DebuggerDisplay("{Count} Headers")]
    public class HttpHeaders : IHttpHeaders
    {
        private readonly IDictionary<string, string> _values;

        public HttpHeaders(IDictionary<string, string> values)
        {
            _values = values;
        }

        public string GetByName(string name)
        {
            return _values[name];
        }
        public bool TryGetByName(string name, out string value)
        {
            return _values.TryGetValue(name, out value);
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
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        internal int Count
        {
            get
            {
                return _values.Count;
            }
        }
    }
}