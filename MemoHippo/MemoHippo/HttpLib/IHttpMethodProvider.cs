namespace HttpLib
{
    public interface IHttpMethodProvider
    {
        HttpMethods Provide(string name);
    }
}