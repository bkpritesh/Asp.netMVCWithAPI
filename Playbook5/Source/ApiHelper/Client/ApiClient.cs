using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using web.ApiHelper.Implementation;

namespace web.ApiHelper.Client
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly UserSessionBus _userSessionBus;
        public ApiClient(HttpClient httpClient )
        {
            _userSessionBus = new UserSessionBus();
            _httpClient = httpClient; 
        }

        public async Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values)
        {
            AddToken();
            using (var content = new FormUrlEncodedContent(values))
            {
                var query = await content.ReadAsStringAsync();
                var requestUriWithQuery = string.Concat(requestUri, "?", query);
                var response = await _httpClient.GetAsync(requestUriWithQuery);
                return response;
            }
        }

        public async Task<HttpResponseMessage> PostFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values)
        {
            using (var content = new FormUrlEncodedContent(values))
            {
                var response = await _httpClient.PostAsync(requestUri, content);
                return response;
            }
        }

        public async Task<HttpResponseMessage> PostJsonEncodedContent<T>(string requestUri, T content) where T :    class
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            AddToken();
            var response = await _httpClient.PostAsJsonAsync(requestUri, content);
            return response;
        }

        public async Task<HttpResponseMessage> GetJsonEncodedContent(string requestUri)
        {
            AddToken();
            var response = await _httpClient.GetAsync(requestUri);
            return response;
        }

        private void AddToken()
        {
            if (_userSessionBus.BearerToken  != null)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (_userSessionBus.BearerToken.StartsWith("Bearer") ? _userSessionBus.BearerToken.Replace("Bearer","") : _userSessionBus.BearerToken));
            }
        }
    }
}