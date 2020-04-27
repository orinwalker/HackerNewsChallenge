using HackerNewsModernUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Services
{
    public interface IHackerNewsService
    {
        Task<HackerNewsArticle> GetNewsAsync(int articleId);
        Task<IEnumerable<int>> GetTopStoriesAsync();
        Task<IEnumerable<IHackerNewsArticle>> GetAllTopStoriesAsync();
    }
}
