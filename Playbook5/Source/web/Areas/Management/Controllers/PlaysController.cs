using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using web.Areas.Management.Models.TeamManagement;
using web.Areas.Management.ViewModels;

namespace web.Areas.Management.Controllers
{
    public class PlaysController : Controller
    {
        // GET: Management/Plays
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Library(string teamId)
        {
            PlayViewModel model = new PlayViewModel();
            await model.Load(teamId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SavePlay(string teamId, Models.TeamManagement.Play play)
        {
            var viewModel = new TeamViewModel();
            play.TeamId = teamId;
            await viewModel.Load(teamId);
            if (Request.Form["PlaybookType"] == "Offense")
            {
                if (viewModel.Team.Playbooks.FirstOrDefault(x => x.PlaybookType.Name == Request.Form["PlaybookType"] || x.PlaybookType.FriendlyName == Request.Form["PlaybookType"]) != null)
                {
                    play.PlaybookId = viewModel.Team.Playbooks.FirstOrDefault(x => x.PlaybookType.Name == Request.Form["PlaybookType"] || x.PlaybookType.FriendlyName == Request.Form["PlaybookType"]).Id;
                }
                else
                {
                    PlayBook newPlaybook = new PlayBook();
                    newPlaybook.TeamId = teamId;
                    newPlaybook.PlaybookType = new PlaybookTypes { Name = "Offense", FriendlyName = "Offense" };
                    var playBookResult = await viewModel.CreateUpdateTeamPlayBook(newPlaybook);
                    play.PlaybookId = playBookResult.Id;

                }

            }
            else if (Request.Form["PlaybookType"] == "Defense")
            {
                if (viewModel.Team.Playbooks.FirstOrDefault(x => x.PlaybookType.Name == Request.Form["PlaybookType"] || x.PlaybookType.FriendlyName == Request.Form["PlaybookType"]) != null)
                {
                    play.PlaybookId = viewModel.Team.Playbooks.FirstOrDefault(x => x.PlaybookType.Name == Request.Form["PlaybookType"] || x.PlaybookType.FriendlyName == Request.Form["PlaybookType"]).Id;
                }
                else
                {
                    PlayBook newPlaybook = new PlayBook();
                    newPlaybook.TeamId = teamId;
                    newPlaybook.PlaybookType = new PlaybookTypes { Name = "Defense", FriendlyName = "Defense" };
                    var playResult = await viewModel.CreateUpdateTeamPlayBook(newPlaybook);
                    play.PlaybookId = playResult.Id;
                }

            }
            else if (Request.Form["PlaybookType"] == "Special Team")
            {
                if(viewModel.Team.Playbooks.FirstOrDefault(x => x.PlaybookType.Name == Request.Form["PlaybookType"] || x.PlaybookType.FriendlyName == Request.Form["PlaybookType"]) != null)
                {
                    play.PlaybookId = viewModel.Team.Playbooks.FirstOrDefault(x => x.PlaybookType.Name == Request.Form["PlaybookType"] || x.PlaybookType.FriendlyName == Request.Form["PlaybookType"]).Id;
                }
                else
                {
                    PlayBook newPlaybook = new PlayBook();
                    newPlaybook.TeamId = teamId;
                    newPlaybook.PlaybookType = new PlaybookTypes { Name = "Special Team", FriendlyName = "Special Team" };
                    var playResult = await viewModel.CreateUpdateTeamPlayBook(newPlaybook);
                    play.PlaybookId = playResult.Id;
                }
                
            }

            play.RecommendedPlays = Request.Form["RecommendedPlaysHidden"].Split(',').Where(x => !string.IsNullOrEmpty(x)).Select(x => new RecommendedPlay { PlayId = x }).ToList();

            play.TeamName = viewModel.Team.Name;

            play.OffenseFormation.Name = play.OffenseFormation.FriendlyDisplay;

            play.DefenseFormation = new Models.TeamManagement.DefenseFormation();
            play.DefenseFormation.Name = "Defense";
            play.DefenseFormation.FriendlyDisplay = "Defense";
            play.DefenseFormation.Id = 1;

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    if (Request.Files.AllKeys.Contains("filepreview"))
                    {
                        var file = Request.Files["filepreview"];
                        MemoryStream target = new MemoryStream();
                        file.InputStream.CopyTo(target);
                        byte[] data = target.ToArray();
                        if (data.Length > 0)
                            play.PreviewUrl = await viewModel.UploadPreview(viewModel.Team.Name, "0", file.FileName, data, file.ContentLength, "UploadPreviewFiles", file.ContentType);
                    }

                    if (Request.Files.AllKeys.Contains("file"))
                    {
                        var file = Request.Files["file"];
                        MemoryStream target = new MemoryStream();
                        file.InputStream.CopyTo(target);
                        byte[] data = target.ToArray();
                        if (data.Length > 0)
                            play.SvgUrl = await viewModel.UploadPreview(viewModel.Team.Name, "0", file.FileName, data, file.ContentLength, "uploadedFile", file.ContentType);
                    }
                }

                if (await viewModel.SavePlay(play))
                {
                    TempData["ErrorMessage"] = "New play has been added to team";
                }
                else
                {
                    TempData["ErrorMessage"] = "There is some problem in adding play to team";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Please review fields";
            }
            ActionResult result;
            result = RedirectToAction("Library", new { teamId = teamId });
            return await Task.FromResult(result);
        }
        [HttpGet]
        public async Task<ActionResult> DeletePlayById(string id, string teamId)
        {
            var viewModel = new TeamViewModel();
            if (await viewModel.DeletePlayById(id))
            {
                TempData["ErrorMessage"] = "Play is deleted from install";
            }
            else
            {
                TempData["ErrorMessage"] = "There is some problem in deleting play";
            }

            ActionResult result;
            result = RedirectToAction("Library", new { teamId = teamId });
            return await Task.FromResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetPlayDetail(string teamId, string playId, string playbookType)
        {
            try
            {
                var viewModel = new TeamViewModel();
                await viewModel.Load(teamId);
                var play = viewModel.Team.Plays.FirstOrDefault(x => x.Id == playId);
                play.RecommendedPlayList = JsonConvert.SerializeObject(play.RecommendedPlays);
                ViewData["TeamId"] = teamId;
                ViewData["PlaybookType"] = playbookType;
                if (playbookType == "Offense")
                {
                    var defensePlaybooks = viewModel.Team.Playbooks.Where(x => x.PlaybookType.Name == "Defense" || x.PlaybookType.FriendlyName == "Defense").Select(x => x.Id).ToList();
                    ViewData["RecommendedPlays"] = viewModel.Team.Plays.Where(x => defensePlaybooks.Contains(x.PlaybookId)).ToList();
                }
                else if (playbookType == "Defense")
                {
                    var offensePlaybooks = viewModel.Team.Playbooks.Where(x => x.PlaybookType.Name == "Offense" || x.PlaybookType.FriendlyName == "Offense").Select(x => x.Id).ToList();
                    ViewData["RecommendedPlays"] = viewModel.Team.Plays.Where(x => offensePlaybooks.Contains(x.PlaybookId)).ToList();
                }
                else if (playbookType == "Special Team")
                {
                    var specialPlaybooks = viewModel.Team.Playbooks.Where(x => x.PlaybookType.Name == "Special Team" || x.PlaybookType.FriendlyName == "Special Team").Select(x => x.Id).ToList();
                    ViewData["RecommendedPlays"] = viewModel.Team.Plays.Where(x => specialPlaybooks.Contains(x.PlaybookId)).ToList();
                }
                else
                {
                    ViewData["RecommendedPlays"] = viewModel.Team.Plays.ToList();
                }
                return PartialView("_AddPlayForm", play);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}