using HackerNewsModernUI.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HackerNewsModernUI.Services
{
    // TODO: For all of these methods: Read the timespan from the config file
    public class HackerNewsCachedService : IHackerNewsService, IHackerNewsCachedService
    {
        private IHackerNewsService _innerHackerNewsService;
        private IMemoryCache _memoryCache;
        public HackerNewsCachedService(IHackerNewsService hackerNewsService, IMemoryCache memoryCache)
        {
            _innerHackerNewsService = hackerNewsService;
            _memoryCache = memoryCache;
        }

        public async Task<HackerNewsArticle> GetNewsAsync(int articleId)
        {
            var cacheKey = "HackerNewsServiceCaching.GetNewsAsync." + articleId;
            if (_memoryCache.TryGetValue<HackerNewsArticle>(cacheKey, out var articleTask))
            {
                return articleTask;
            }
            else
            {
                var hackerNewsArticle = await _innerHackerNewsService.GetNewsAsync(articleId);
                _memoryCache.Set(cacheKey, hackerNewsArticle, TimeSpan.FromMinutes(10));
                return hackerNewsArticle;
            }
        }

        public async Task<IEnumerable<int>> GetTopArticleIdsAsync()
        {
            var cacheKey = "HackerNewsServiceCaching.GetTopStoriesAsync";
            if (_memoryCache.TryGetValue<IEnumerable<int>>(cacheKey, out var storyTask))
            {
                return storyTask;
            }
            else
            {
                var topStories = await _innerHackerNewsService.GetTopArticleIdsAsync();
                _memoryCache.Set(cacheKey, topStories, TimeSpan.FromMinutes(10));
                return topStories;
            }
        }

        public async Task<IEnumerable<IHackerNewsArticle>> GetAllTopStoriesAsync()
        {
            var cacheKey = "HackerNewsServiceCaching.GetAllTopStoriesAsync";
            if (_memoryCache.TryGetValue<IEnumerable<IHackerNewsArticle>>(cacheKey, out var storyTask))
            {
                return storyTask;
            }
            else
            {
                var topStories = await _innerHackerNewsService.GetAllTopStoriesAsync();
                _memoryCache.Set(cacheKey, topStories, TimeSpan.FromMinutes(10));
                return topStories;
            }
        }

        public async Task<IEnumerable<IHackerNewsArticle>> SearchTopStoriesAsync(string searchTerm)
        {
            // TODO: This could be more elegant (rather than returning nothing return something meaningful)
            if (searchTerm.Length > 50)
                return null;

            // Sanitize input
            searchTerm = HttpUtility.HtmlEncode(searchTerm);

            var cacheKey = "HackerNewsServiceCaching.SearchTopStoriesAsync." + searchTerm.ToLower();
            if (_memoryCache.TryGetValue<IEnumerable<IHackerNewsArticle>>(cacheKey, out var storyTask))
            {
                return storyTask;
            }
            else
            {
                var response = await this.GetAllTopStoriesAsync();
                if (response.Count() > 0) {
                    var topStories = response.ToList();
                    var searchResult = topStories.Where(s => s.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
                    return searchResult;
                }
                else
                {
                    var topSearched = await _innerHackerNewsService.SearchTopStoriesAsync(searchTerm);
                    _memoryCache.Set(cacheKey, topSearched, TimeSpan.FromMinutes(10));
                    return topSearched;
                }
            }
        }
    }
}
