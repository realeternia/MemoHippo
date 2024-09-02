using System.Collections.Generic;

namespace HttpLib.Headers
{
    public interface IHttpHeaders : IEnumerable<KeyValuePair<string, string>>
    {

        string GetByName(string name);

        bool TryGetByName(string name, out string value);
        Dictionary<string, string> GetManyByName(List<string> names);

    }
}