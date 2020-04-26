using HackerNewsModernUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Services
{
    public interface IHackerNewsCachedService
    {
        Task<HackerNewsArticle> GetNewsAsync(int articleId);
        Task<IEnumerable<int>> GetTopStoriesAsync();
    }
}