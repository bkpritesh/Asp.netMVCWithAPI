using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using web.ApiHelper.Implementation;

namespace web.ApiInfrastructure.Client
{
    public class RestHelper
    {
        private readonly UserSessionBus _userSessionBus;
        public const string BASEURL = "http://playbook5servicev2.azurewebsites.net/";
        RestClient client;
        CancellationTokenSource CancellationTokenSource;
        public RestHelper()
        {
            client = new RestClient(BASEURL);
            _userSessionBus = new UserSessionBus();
            CancellationTokenSource = new CancellationTokenSource();
        }

        public async Task<T> Get<T>(string uri) where T : new()
        {
            AddToken();
            var request = new RestRequest(uri, Method.GET);
            var response = await client.ExecuteTaskAsync<T>(request, CancellationTokenSource.Token);
            if (response.Data != null)
            {
                return response.Data;
            }
            return default(T);
        }

        public async Task<bool> Get(string uri)
        {
            AddToken();
            var request = new RestRequest(uri, Method.GET);
            var response = await client.ExecuteTaskAsync(request, CancellationTokenSource.Token);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<T> Post<T>(string uri, object model) where T : new()
        {
            AddToken();
            var request = new RestRequest(uri, Method.POST);
            if (model != null)
            {
                request.AddJsonBody(model);
            }
            var response = await client.ExecuteTaskAsync<T>(request, CancellationTokenSource.Token);
            if (response.Data != null)
            {
                return response.Data;
            }
            return default(T);
        }

        public async Task<bool> Post(string uri, object model)
        {
            AddToken();
            var request = new RestRequest(uri, Method.POST);
            if (model != null)
            {
                request.AddJsonBody(model);
            }
            var response = await client.ExecuteTaskAsync(request, CancellationTokenSource.Token);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<string> Upload(string uri, string fileName, byte[] fileBytes, int contentLength, string parameterName, string contentType)
        {
            AddToken();
            IRestRequest request = new RestRequest(uri, Method.POST);
            request.AddHeader("Content-Length", contentLength.ToString());
            request.AddFileBytes(parameterName, fileBytes, fileName, contentType);

            IRestResponse response = await client.ExecuteTaskAsync(request, CancellationTokenSource.Token);
            return JsonConvert.DeserializeObject<string>(response.Content);
        }

        void AddToken()
        {
            if (_userSessionBus.BearerToken != null)
            {
                client.AddDefaultHeader(HttpRequestHeader.Authorization.ToString(), $"Bearer {(_userSessionBus.BearerToken.StartsWith("Bearer") ? _userSessionBus.BearerToken.Replace("Bearer", "") : _userSessionBus.BearerToken)}");
            }
        }

    }
}