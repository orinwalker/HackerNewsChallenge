using System;
using System.Collections.Generic;

namespace HackerNewsModernUI.Models
{
    public interface IHackerNewsArticle
    {
        string By { get; set; }
        int Descendants { get; set; }
        int Id { get; set; }
        IList<int> Kids { get; set; }
        int Score { get; set; }
        int Time { get; set; }
        public DateTime UtcDateTime { get; }
        public string HowLongAgo { get;  }
        string Title { get; set; }
        string Type { get; set; }
        string Url { get; set; }
    }
}