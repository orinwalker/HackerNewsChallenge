using HackerNewsModernUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Services
{
    public interface IHackerNewsCachedService
    {
        Task<IEnumerable<IHackerNewsArticle>> SearchTopStoriesAsync(string searchTerm);
        Task<HackerNewsArticle> GetNewsAsync(int articleId);
        Task<IEnumerable<int>> GetTopArticleIdsAsync();
        Task<IEnumerable<IHackerNewsArticle>> GetAllTopStoriesAsync();
    }
}