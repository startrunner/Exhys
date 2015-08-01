﻿using System;
using System.Linq;
using System.Web;
using Exhys.WebContestHost.DataModels;

namespace Exhys.WebContestHost.Areas.Shared.Extensions
{
    public static class HttpRequestBase_Extensions
    {
        public static UserAccount GetSignedInUser(this HttpRequestBase that)
        {
            using (var db = new ExhysContestEntities())
            {
                return that.GetSignedInUser(db);
            }
        }
        public static UserAccount GetSignedInUser (this HttpRequestBase request, ExhysContestEntities db)
        {
            Guid? sessionId = request.GetSessionCookie();
            if (sessionId == null) return null;
            var sessions = db
                .UserSessions
                .Where(s =>
                    s.Id == sessionId &&
                    s.BrowserName == request.Browser.Browser &&
                    s.UserAgentString == request.UserAgent)
                .Take(1)
                .ToList();
            if (sessions == null || sessions.Count == 0) return null;
            else return sessions[0].UserAccount;
            
        }

        public static Guid? GetSessionCookie(this HttpRequestBase req)
        {
            try
            {
                return Guid.Parse(req.Cookies.Get(CookieNames.SessionCookieName).Value);
            }
            catch
            {
                return null;
            }
        }

    }
}