﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Exhys.WebContestHost.Areas.Shared;
using Exhys.WebContestHost.Areas.Shared.ViewModels;
using Exhys.WebContestHost.DataModels;
using CodeBits;
using Exhys.WebContestHost.Areas.Shared.Mvc;
using Exhys.WebContestHost.Areas.Shared.Extensions;

namespace Exhys.WebContestHost.Areas.Administration.Controllers
{
    public class UserAccountsController : ExhysController
    {
        private const int List_PageSize= 40;
		[HttpGet]
        public ActionResult List(uint? page)
        {
            if (page == null) page = 1;

            AddSignedInUserInformation();
            AddUserGroupOptions();

			using (var db=new ExhysContestEntities())
            {
                int itemCount = db.UserAccounts.Count();

                ViewData.SetPageSize(List_PageSize);
                ViewData.SetPageCount(itemCount / List_PageSize + (itemCount % List_PageSize == 0 ? 0 : 1));
                ViewData.SetCurrentPage((int)page);


                var vm = new List<UserAccountViewModel>();

                int skip = (int)((((int)page) - 1) * List_PageSize);

                db.UserAccounts
                    .OrderBy(a=>a.Username)
                    .Skip(skip)
                    .Take(List_PageSize)
                    .ToList()
                    .ForEach((acc) =>
                    {
                        vm.Add(new UserAccountViewModel(acc));
                    });
                return View(vm);
            }
        }

        [HttpPost]
        public ActionResult List (List<UserAccountViewModel> vm)
        {
            using (var db = new ExhysContestEntities())
            {
                foreach (var v in vm)
                {
                    var user = db.UserAccounts
                        .Where(u => u.Id == v.UserId).FirstOrDefault();
                    if (v.RequestDelete == false)
                    {
                        user.FullName = v.FullName;
                        user.Password = v.Password;
                        var gr = db.UserGroups.Where(g => g.Id == v.GroupId).FirstOrDefault();
                        user.UserGroup = gr;
                    }
                    else
                    {
                        db.UserAccounts.Remove(user);
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult AddUsers()
        {
            AddSignedInUserInformation();
            AddUserGroupOptions();

            return View();
        }

        [HttpPost]
        public ActionResult AddUsers (string prefix, int? count, string fullNames, int groupId)
        { 
            if (prefix == null || count == null) return RedirectToAction("AddUsers");
            else
            {
                string[] names = fullNames.Split('\n');
                for (int i = 0; i < names.Length; i++) names[i] = names[i].Trim();

                using (var db = new ExhysContestEntities())
                {
                    //var gr = db.GetDefaultUserGroup();
                    var gr = db.UserGroups.Where(g => g.Id == groupId).FirstOrDefault();

                    int addedCount = 0;
                    for (int currentNumber = 0; addedCount != count; currentNumber++)
                    {
                        string currentUsername = string.Format("{0}{1:000}", prefix, currentNumber);

                        var existing = db.UserAccounts.Where(u => u.Username == currentUsername).FirstOrDefault();
                        if (existing != null)
                        {
                            //currentUsername is taken
                            continue;
                        }

                        var user = new UserAccount()
                        {
                            Username = currentUsername,
                            Password = PasswordGenerator.Generate(6, PasswordCharacters.AlphaNumeric).ToLower(),
                            FullName = addedCount < names.Length ? names[addedCount] : "",
                            UserGroup = gr
                        };
                        db.UserAccounts.Add(user);
                        addedCount++;
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
        }
    }
}