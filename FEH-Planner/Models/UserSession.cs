using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FEH_Planner.Models
{
    public class UserSession
    {
        private const string RecentsKey = "recentpages";
        private const string CountKey = "recentscount";

        private ISession session { get; set; }

        public UserSession(ISession sess)
        {
            session = sess;
        }

        public void AddRecentPage(Build build)
        {
            List<Build> newList = GetMyRecentPages();

            newList.RemoveAll(b => b.BuildID == build.BuildID);

            newList.Insert(0, build);

            SetMyRecentPages(newList);
        }

        public void SetMyRecentPages(List<Build> builds)
        {
            session.SetObject(RecentsKey, builds);
            session.SetInt32(CountKey, builds.Count);
        }

        public List<Build> GetMyRecentPages() => session.GetObject<List<Build>>(RecentsKey) ?? new List<Build>();
        public int? GetMyRecentPagesCount() => session.GetInt32(CountKey);

        public void RemoveRecentPage(Build build)
        {
            List<Build> newList = GetMyRecentPages();

            newList.RemoveAll(b => b.BuildID == build.BuildID);

            SetMyRecentPages(newList);
        }

        public void RemoveMyRecentPages()
        {
            session.Remove(RecentsKey);
            session.Remove(CountKey);
        }
    }
}
