using Profixer.Providers.Interfaces;

namespace Profixer.Providers.Services
{
    public class ClientService : IClient
    {
        public ClientService()
        {
        }

        public async Task<HttpResponseMessage> Post(string apiUrl, string data)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                return response;
            }
        }

        public async Task<HttpResponseMessage> Get(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                return response;
            }
        }
    }
}