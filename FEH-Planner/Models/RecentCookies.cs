using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FEH_Planner.Models
{
    public class RecentCookies
    {
        private string MyRecentPages = "";

        private const string Name = "recentpages";
        private const char Delimiter = '-';

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public RecentCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public RecentCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void AddRecentPage(Build build)
        {
            MyRecentPages = build.BuildID.ToString() + Delimiter + MyRecentPages;

            if (MyRecentPages.Count(c => c == Delimiter) > 5)
            {
                string[] rp = MyRecentPages.Split('-');

                MyRecentPages = rp[0]
                    + Delimiter + rp[1]
                    + Delimiter + rp[2]
                    + Delimiter + rp[3]
                    + Delimiter + rp[4];
            }

            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1)
            };

            RemoveMyRecentPages();
            responseCookies.Append(Name, MyRecentPages);
        }

        public string[] GetMyRecentPages()
        {
            string cookie = requestCookies[Name];

            if (string.IsNullOrEmpty(cookie))
            {
                return new string[] { };
            }
            else
            {
                return cookie.Split(Delimiter);
            }
        }

        public void RemoveMyRecentPages()
        {
            responseCookies.Delete(MyRecentPages);
        }
    }
}
