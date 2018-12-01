using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web.ApiHelper.Client;
using web.ApiInfrastructure;
using web.ApiInfrastructure.ApiModels;
using web.ApiInfrastructure.Client;
using web.Areas.Management.Models.TeamManagement;

namespace web.Models
{
    public static class Utils
    {
        public static async Task<List<CountryApiModel>> GetAllCountry()
        {
            try
            {
                var apiClient = new ApiClient(HttpClientInstance.Instance);
                var _countryClient = new CountryClient(apiClient);
                var response = await _countryClient.GetAllCountry();
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<SelectListItem> GetPersonnels()
        {
            List<SelectListItem> personnnels = new List<SelectListItem>();

            personnnels.Add(new SelectListItem { Value = "-1", Selected = true, Text = "" });
            personnnels.Add(new SelectListItem { Value = "00", Text = "00" });
            personnnels.Add(new SelectListItem { Value = "01", Text = "01" });
            personnnels.Add(new SelectListItem { Value = "02", Text = "02" });
            personnnels.Add(new SelectListItem { Value = "10", Text = "10" });
            personnnels.Add(new SelectListItem { Value = "11", Text = "11" });
            personnnels.Add(new SelectListItem { Value = "12", Text = "12" });
            personnnels.Add(new SelectListItem { Value = "13", Text = "13" });
            personnnels.Add(new SelectListItem { Value = "20", Text = "20" });
            personnnels.Add(new SelectListItem { Value = "21", Text = "21" });
            personnnels.Add(new SelectListItem { Value = "22", Text = "22" });
            personnnels.Add(new SelectListItem { Value = "23", Text = "23" });
            return personnnels;
        }

        public static List<SelectListItem> GetPositions()
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "None",
                Text = "None"
            });

            selectList.Add(new SelectListItem
            {
                Value = "QB",
                Text = "QB"
            });
            selectList.Add(new SelectListItem
            {
                Value = "RB",
                Text = "RB"
            });
            selectList.Add(new SelectListItem
            {
                Value = "WR",
                Text = "WR"
            });
            selectList.Add(new SelectListItem
            {
                Value = "TE",
                Text = "TE"
            });
            selectList.Add(new SelectListItem
            {
                Value = "OL",
                Text = "OL"
            });
            selectList.Add(new SelectListItem
            {
                Value = "Coach",
                Text = "Coach"
            });

            return selectList;
        }

    }
}
