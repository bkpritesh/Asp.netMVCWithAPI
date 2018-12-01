using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace web.ApiHelper.Client
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values);
        Task<HttpResponseMessage> PostFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values);
        Task<HttpResponseMessage> PostJsonEncodedContent<T>(string requestUri, T content) where T : class;
        Task<HttpResponseMessage> GetJsonEncodedContent(string requestUri);
        
    }
}