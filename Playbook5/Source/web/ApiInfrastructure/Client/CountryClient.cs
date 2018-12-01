using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using web.ApiHelper.Client;
using web.ApiInfrastructure.ApiModels;
using web.Models;

namespace web.ApiInfrastructure.Client
{
    public class CountryClient : ClientBase, ICountryClient
    {
        private static readonly string BaseUrl = AppConst.WebApiUrl;
        private static readonly string GetCountriesUri = BaseUrl + "/TeamManagement/GetAllCountries";

        public CountryClient(IApiClient apiClient) : base(apiClient)

        {
        }
        public async Task<List<CountryApiModel>> GetAllCountry()
        {
            var response = await ApiClient.GetJsonEncodedContent(GetCountriesUri);
            return await DecodeContent<List<CountryApiModel>>(response);
        }
    }
}