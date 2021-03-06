﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exhys.WebContestHost.Areas.Shared.Extensions;
using Exhys.WebContestHost.Areas.Shared.Mvc;
using Exhys.WebContestHost.Areas.Shared.ViewModels;
using Exhys.WebContestHost.DataModels;
using System.Data.Entity;

namespace Exhys.WebContestHost.Areas.Participation.Controllers
{
    public class CompetitionsController : ExhysController
    {
        private ActionResult RedirectToSignIn()
        {
            return RedirectToAction(controllerName: "../Accounts/Accounts", actionName: "SignIn", routeValues: new { });
        }
        private ActionResult RedirectToList()
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            var vm = new List<CompetitionViewModel>();

            using (var db = new ExhysContestEntities())
            {
                var user = Request.GetSignedInUser(db);
                if (user == null) return RedirectToSignIn();

                db.Entry(user)
                    .Reference(u => u.UserGroup)
                    .Query()
                    .Include(u => u.AvaiableCompetition).Load();

                var competitions = user.UserGroup.AvaiableCompetition.ToList();
                foreach (var comp in competitions) vm.Add(new CompetitionViewModel(comp));
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult Join(int id)
        {
            using (var db = new ExhysContestEntities())
            {
                var competition = db.Competitions.Where(c => c.Id == id).FirstOrDefault();
                if(competition==null)
                {
                    return RedirectToList();
                }
                else
                {
                    return View(new CompetitionViewModel(competition));
                }
            }
        }

        [HttpPost]
        public ActionResult Join(CompetitionViewModel vm)
        {
            using (var db = new ExhysContestEntities())
            {
                var competition = db.Competitions.Where(c => c.Id == vm.Id).FirstOrDefault();
                if (competition == null) return RedirectToAction("List");

                var user = Request.GetSignedInUser(db);
                if (user == null) return RedirectToSignIn();

                var participation=db.Participations
                    .Where(p=>p.User.Id==user.Id && p.Competition.Id==competition.Id)
                    .FirstOrDefault();
                if (participation != null) return RedirectToAction("Participate", new { id = vm.Id });

                participation = new DataModels.Participation();
                db.Entry(participation).State = EntityState.Added;

                participation.Competition = competition;
                participation.User = user;

                db.SaveChanges();

                
            }
            return RedirectToList();
        }

        [HttpGet]
        public ActionResult Participate(int id)
        {
            using (var db = new ExhysContestEntities())
            {
                var competition = db.Competitions.Where(c => c.Id == id).FirstOrDefault();
                if (competition == null) return RedirectToList();

                var user = Request.GetSignedInUser(db);
                if (user == null) return RedirectToSignIn();

                var participation = db.Participations
                    .Where(p => p.User.Id == user.Id && p.Competition.Id == competition.Id)
                    .Include(p => p.Competition.Problems.Select(prob=>prob.ProblemStatements))
                    .FirstOrDefault();
                if (participation == null) return RedirectToList();

                var vm = new ParticipationViewModel(participation);
                vm.Competition.IncludeProblems().IncludeProblemStatements();

                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult DownloadStatement(int id)
        {
            using (var db = new ExhysContestEntities())
            {
                ProblemStatement statement = db.ProblemStatements
                    .Where(s => s.Id == id)
                    .FirstOrDefault();

                return File(fileContents: statement.Bytes, fileDownloadName: statement.Filename, contentType: "application/zip");
            }
        }


    }
}