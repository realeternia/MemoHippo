using System.Threading.Tasks;

namespace HttpLib.Handlers
{
    public interface IResponseProvider
    {

        Task<IHttpResponse> Provide(object value, HttpResponseCode responseCode = HttpResponseCode.Ok);

    }
}