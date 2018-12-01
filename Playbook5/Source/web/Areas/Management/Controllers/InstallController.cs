using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web.Areas.Management.Models.TeamManagement;
using web.Areas.Management.ViewModels;

namespace web.Areas.Management.Controllers
{
    public class InstallController : Controller
    {
        // GET: Management/Install
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Install(string teamId)
        {
            PlayViewModel model = new PlayViewModel();
            await model.Load(teamId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveInstall(string teamId, [Bind(Include = "Id,Date,TeamInstallId,Title,Description,Active,CoachId")] TeamInstallDTO teamInstall)
        {
            TeamViewModel model = new TeamViewModel();
            teamInstall.TeamId = teamId.Trim();
            if (!string.IsNullOrEmpty(Request.Form["DateIssue"]))
                teamInstall.Date = Convert.ToDateTime(Request.Form["DateIssue"]);
            if (await model.CreateUpdateTestInstall(teamInstall))
            {
                if (!string.IsNullOrEmpty(teamInstall.Id))
                {
                    List<TeamUser> teamUsers = await model.GetUsersByTeamId(teamInstall.TeamId);
                    foreach (var user in teamUsers)
                    {
                        var emailResponse = await model.SendInstallNotification(new EmailDTO { To = user.Email, Subject = "PlayBool5 Install Notification", Body = "New Install '" + teamInstall.Title + "' is created in your team" });
                    }
                }

                TempData["ErrorMessage"] = "Install added to team";
            }
            else
            {
                TempData["ErrorMessage"] = "There is some problem in adding install to team";
            }

            ActionResult result;
            result = RedirectToAction("Install", new { teamId = teamId });
            return await Task.FromResult(result);
        }

        [HttpPost]
        public async Task<ActionResult> SavePlayToTeam(string Id, string teamId, string InstallPlay, TeamInstallDTO model)
        {
            TeamViewModel viewModel = new TeamViewModel();
            if (InstallPlay != "-1")
            {
                if (await viewModel.InsertInstallPlay(Id, InstallPlay))
                {
                    TempData["ErrorMessage"] = "Play added to team";
                }
                else
                {
                    TempData["ErrorMessage"] = "There is some problem in adding play to team";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Please select play";
            }

            ActionResult result;
            result = RedirectToAction("Install", new { teamId = teamId });
            return await Task.FromResult(result);
        }

        [HttpPost]
        public async Task<ActionResult> SaveTeamNotes(string teamId, [Bind(Include = "Id, Content")] TeamNote teamNote)
        {
            PlayViewModel model = new PlayViewModel();
            teamNote.TeamId = teamId;
            if (!string.IsNullOrEmpty(teamNote.Id))
            {
                if (await model.CreateTeamNotes(teamNote))
                {
                    TempData["ErrorMessage"] = "Note added to team";
                }
                else
                {
                    TempData["ErrorMessage"] = "There is some problem in adding note to team";
                }
            }
            else
            {
                if (await model.CreateTeamNotes(teamNote))
                {
                    TempData["ErrorMessage"] = "Note updated to team";
                }
                else
                {
                    TempData["ErrorMessage"] = "There is some problem in updating note to team";
                }
            }

            ActionResult result;
            result = RedirectToAction("Install", new { teamId = teamId });
            return await Task.FromResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteInstallPlay(string id, string playId, string teamId)
        {
            var viewModel = new TeamViewModel();
            if (await viewModel.DeleteInstallPlay(id, playId))
            {
                TempData["ErrorMessage"] = "Install play is deleted from install";
            }
            else
            {
                TempData["ErrorMessage"] = "There is some problem in deleting install play";
            }

            ActionResult result;
            result = RedirectToAction("Install", new { teamId = teamId });
            return await Task.FromResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetInstallDetailPartial(string teamId, string installId)
        {
            try
            {
                var viewModel = new TeamViewModel();
                await viewModel.Load(teamId);
                var install = viewModel.Team.TeamInstall.TeamInstalls.FirstOrDefault(x => x.Id == installId);
                ViewData["TeamId"] = teamId;

                var playViewModel = new PlayViewModel();
                await playViewModel.Load(teamId);
                var coachUsers = playViewModel.TeamUsers.Where(x => x.Roles.Contains("Coach")).ToList();
                ViewData["Users"] = coachUsers;
                return PartialView("_AddEditTeamInstall", install);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteTeamNotesById(string id, string teamId)
        {
            //var viewModel = new TeamViewModel();
            PlayViewModel viewModel = new PlayViewModel();
            if (await viewModel.DeleteTeamNotesById(id))
            {
                TempData["ErrorMessage"] = "Team Note is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "There is some problem in deleting team Note";
            }

            ActionResult result;
            result = RedirectToAction("Install", new { teamId = teamId });
            return await Task.FromResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetTeamNoteDetail(string teamId, string Id)
        {
            try
            {
                var viewModel = new PlayViewModel();
                await viewModel.Load(teamId);
                var teamNote = viewModel.TeamNotes.TeamNotes.FirstOrDefault(x => x.Id == Id);
                ViewData["TeamId"] = teamId;
                ViewData["Id"] = Id;
                return PartialView("_AddEditTeamNotes", teamNote);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetInstallPlayDetail(string teamId, string playId)
        {
            try
            {
                var viewModel = new InstallPlayViewModel();
                await viewModel.Load(playId);

                ViewData["TeamId"] = teamId;
                return PartialView("_ViewInstallPlayContentPartial", viewModel);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}