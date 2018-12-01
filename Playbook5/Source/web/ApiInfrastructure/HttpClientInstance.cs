using System;
using System.Net.Http;

namespace web.ApiInfrastructure
{
    public static class HttpClientInstance
    {
        private const string BaseUri = "Http://localhost:28550/";

        public static HttpClient Instance { get; } = new HttpClient {BaseAddress = new Uri(BaseUri)};
    }
}