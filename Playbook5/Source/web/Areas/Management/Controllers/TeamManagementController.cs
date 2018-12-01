#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using web.ApiHelper.Client;
using web.ApiInfrastructure;
using web.ApiInfrastructure.ApiModels;
using web.ApiInfrastructure.Client;
using web.Areas.Management.Models;
using web.Areas.Management.Models.TeamManagement;
using web.Areas.Management.ViewModels;
using web.Models;

#endregion

namespace web.Areas.Management.Controllers
{
    [Authorize]
    public class TeamManagementController : Controller
    {
        private readonly ITeamManagementClient _teamManagementClient;
        private readonly ICountryClient _countryClient;

        public TeamManagementController()
        {
            var apiClient = new ApiClient(HttpClientInstance.Instance);
            _teamManagementClient = new TeamManagementClient(apiClient);
            _countryClient = new CountryClient(apiClient);
        }

        // GET: Management/TeamManagement
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Teams()
        {
            TeamViewModel model = new TeamViewModel();
            await model.Load();
            return View(model);
        }

        #region Team Detail

        public async Task<ActionResult> TeamDetails(string id)
        {
            TeamViewModel model = new TeamViewModel();
            if (id != "-1")
            {
                await model.Load(id);
            }
            else
            {
                var allCountries = await model.GetAllCountry();
                model.CountrySelectList = allCountries.Select(c => new SelectListItem { Value = c.Id, Text = c.Name }).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> TeamDetails([Bind(Include = "Team, Team.TeamUsers,Playbooks,Team.Plays,TeamInstall")] TeamViewModel model)
        {
            var allCountries = await model.GetAllCountry();
            if (ModelState.IsValid)
            {
                var country = allCountries.FirstOrDefault(x => x.Id == model.Team.CountryId);
                model.Team.Country = country.Name;
                var response = await model.CreateUpdateTeam();
                if (response != null)
                {
                    TempData["ErrorMessage"] = "Team saved successully";
                    await model.Load(response.Id);
                }
                else
                {
                    TempData["ErrorMessage"] = "There is some problem in saving team";
                }
            }

            //re-fill data to display -- load differently because the team object is edited by user so if we get team detail it will be overwritten.
            
            model.CountrySelectList = allCountries.Select(c => new SelectListItem { Value = c.Id, Text = c.Name }).ToList();
            model.Team.TeamInstall = await model.GetAllTeamInstalledByTeamId(model.Team.Id);
            model.Team.TeamUsers = await model.GetUsersByTeamId(model.Team.Id);
            model.Team.Plays = await model.GetAllPlaysByTeamId(model.Team.Id);
            model.Team.Playbooks = await model.GetAllPlaybooksByTeamId(model.Team.Id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveTeamDetails(Team model)
        {
            var viewModel = new TeamViewModel();
            var allCountries = await viewModel.GetAllCountry();
            if (ModelState.IsValid)
            {
                var country = allCountries.FirstOrDefault(x => x.Id == model.CountryId);
                model.Country = country.Name;
                viewModel.Team = model;
                var response = await viewModel.CreateUpdateTeam();
                if (response != null)
                {
                    TempData["ErrorMessage"] = "Team saved successully";
                }
                else
                {
                    TempData["ErrorMessage"] = "There is some problem in saving team";
                }
            }
            ActionResult result;
            result = RedirectToAction("TeamDetails", new { id = model.Id });
            return await Task.FromResult(result);
            //ViewData["CountrySelectList"]= allCountries.Select(c => new SelectListItem { Value = c.Id, Text = c.Name }).ToList();
            //return PartialView("_AddEditTeam", viewModel.Team);
        }

        #endregion Team Details

        #region User Details

        public async Task<ActionResult> UserDetails(string id, string teamId)
        {
            var userViewModel = new UserViewModel();
            await userViewModel.Load(id, teamId);
            if (userViewModel.User == null)
            {
                userViewModel.User = new Models.TeamManagement.User();
            }
            userViewModel.User.TeamId = teamId;

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> UserDetails(string id, string teamId, User model)
        {
            var userViewModel = new UserViewModel();
            if (ModelState.IsValid)
            {
                var roles = await userViewModel.GetAllRoles();
                var role = roles.FirstOrDefault(x => x.Id == model.UserRoleId);
                if (model.Roles == null)
                {
                    model.Roles = new List<string>();
                }
                model.Roles.Add(role.Name);
                model.TeamId = teamId;
                if (await userViewModel.CreateUser(model) == true)
                {
                    TempData["ErrorMessage"] = "User detail saved successfully";
                    await userViewModel.Load(model.Id, model.TeamId);
                }
            }
            else
            {
                TempData["ErrorMessage"] = "There is some problem in saving user detail";
                await userViewModel.Load(model.Id, model.TeamId);
                userViewModel.User = model;
            }
            if (string.IsNullOrEmpty(model.Id))
            {
                ActionResult result;
                result = RedirectToAction("TeamDetails", new { id = teamId });
                return await Task.FromResult(result);
            }
            else
            {
                return View(userViewModel);
            }
        }



        #endregion User Details
    }
}