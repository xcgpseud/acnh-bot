using System.Net.Http;

namespace ACNHBot.Application.Services
{
    public class TNRDService
    {
        protected HttpClient _client;
        protected const string BaseUrl = "https://acnh.tnrd.net/api/v3";

        protected HttpClient GetClient()
        {
            if (_client == null)
            {
                _client = new HttpClient();
            }

            return _client;
        }
    }
}