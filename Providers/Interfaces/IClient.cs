namespace Profixer.Providers.Interfaces
{
    public interface IClient
    {
        Task<HttpResponseMessage> Post(string apiUrl, string data);
        Task<HttpResponseMessage> Get(string apiUrl);
    }
}