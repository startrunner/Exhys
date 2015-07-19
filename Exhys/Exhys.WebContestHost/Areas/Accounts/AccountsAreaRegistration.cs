﻿using System.Web.Mvc;

namespace Exhys.WebContestHost.Areas.Accounts
{
    public class AccountsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Accounts";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Accounts_default",
                "Accounts/{controller}/{action}",
                new { action = "Index", controller="Account"}
            );
        }
    }
}