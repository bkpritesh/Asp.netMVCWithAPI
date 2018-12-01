using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using web.ApiInfrastructure.ApiModels;

namespace web.ApiInfrastructure.Client
{
    public interface ICountryClient
    {
        Task<List<CountryApiModel>> GetAllCountry();
    }
}