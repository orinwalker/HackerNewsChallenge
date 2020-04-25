using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Models
{
    public class HackerNewsArticle : IHackerNewsArticle
    {
        public string By { get; set;}
        public int Descendants { get; set;}
        public int Id { get; set;}
        public IList<int> Kids { get; set;}
        public int Score { get; set;}
        public int Time { get; set;}

        public DateTime UtcDateTime
        {
            get
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(this.Time);
                return dateTimeOffset.UtcDateTime;
            }
        }
        public string HowLongAgo
        {
            get
            {
                return GetHowLongAgo(this.UtcDateTime);
            }
        }
        public string Title { get; set;}
        public string Type { get; set;}
        public string Url { get; set;}

        // TODO: move this to a library/service 
        // TODO: Add some test functions for this one
        private static string GetHowLongAgo(DateTime objDateTime)
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(objDateTime);
            if (ts.Days > 0)
                return string.Format("{0} day{1} ago", ts.Days, ts.Days == 1 ? "" : "s");
            if (ts.Hours > 0)
                return string.Format("{0} hour{1} ago", ts.Hours, ts.Hours == 1 ? "" : "s");
            if (ts.Minutes > 0)
                return string.Format("{0} minute{1} ago", ts.Minutes, ts.Minutes == 1 ? "" : "s");
            if (ts.Seconds > 0)
                return string.Format("{0} second{1} ago", ts.Seconds, ts.Seconds == 1 ? "" : "s");
            return string.Empty;
        }
    }
}
