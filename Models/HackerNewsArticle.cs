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
                return GetTimeSince(this.UtcDateTime);
            }
        }
        public string Title { get; set;}
        public string Type { get; set;}
        public string Url { get; set;}

        // TODO: move this to a library/service 
        // return how much time passed since date object
        // https://www.thatsoftwaredude.com/content/1019/how-to-calculate-time-ago-in-c
        //
        private static string GetTimeSince(DateTime objDateTime)
        {
            // here we are going to subtract the passed in DateTime from the current time converted to UTC
            TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(objDateTime);
            int intDays = ts.Days;
            int intHours = ts.Hours;
            int intMinutes = ts.Minutes;
            int intSeconds = ts.Seconds;

            if (intDays > 0)
                return string.Format("{0} days", intDays);

            if (intHours > 0)
                return string.Format("{0} hours", intHours);

            if (intMinutes > 0)
                return string.Format("{0} minutes", intMinutes);

            if (intSeconds > 0)
                return string.Format("{0} seconds", intSeconds);

            // let's handle future times..just in case
            if (intDays < 0)
                return string.Format("in {0} days", Math.Abs(intDays));

            if (intHours < 0)
                return string.Format("in {0} hours", Math.Abs(intHours));

            if (intMinutes < 0)
                return string.Format("in {0} minutes", Math.Abs(intMinutes));

            if (intSeconds < 0)
                return string.Format("in {0} seconds", Math.Abs(intSeconds));

            return "a bit";
        }
    }
}
