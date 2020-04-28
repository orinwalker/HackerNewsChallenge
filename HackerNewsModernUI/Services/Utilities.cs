using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Services
{
    public class Utilities : IUtilities
    {
        // TODO: move this to a library
        public string GetHowLongAgo(DateTime dt)
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(dt);
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
