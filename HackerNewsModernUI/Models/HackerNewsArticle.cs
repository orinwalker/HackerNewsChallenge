using HackerNewsModernUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Models
{
    public class HackerNewsArticle : IHackerNewsArticle
    {
        private readonly IUtilities _utilities;
        public HackerNewsArticle()
        {
            _utilities = new Utilities();
        }

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
                if (_utilities != null)
                    return _utilities.GetHowLongAgo(this.UtcDateTime);
                else
                    return string.Empty;
            }
        }
        public string Title { get; set;}
        public string Type { get; set;}
        public string Url { get; set;}
    }
}
