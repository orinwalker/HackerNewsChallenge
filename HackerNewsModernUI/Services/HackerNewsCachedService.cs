using HackerNewsModernUI.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Services
{
    // Use decorator pattern to provide caching via the Microsoft IMemoryCache
    public class HackerNewsCachedService : IHackerNewsService, IHackerNewsCachedService
    {
        private IHackerNewsService _innerHackerNewsService;
        private IMemoryCache _memoryCache;
        public HackerNewsCachedService(IHackerNewsService hackerNewsService, IMemoryCache memoryCache)
        {
            _innerHackerNewsService = hackerNewsService;
            _memoryCache = memoryCache;
        }

        // TODO: make async
        public Task<HackerNewsArticle> GetNewsAsync(int articleId)
        {
            var cacheKey = "HackerNewsServiceCaching.GetNewsAsync" + articleId;
            if (_memoryCache.TryGetValue<Task<HackerNewsArticle>>(cacheKey, out var articleTask))
            {
                return articleTask;
            }
            else
            {
                // TODO: Read the timespan here from the config file
                var hackerNewsArticle = _innerHackerNewsService.GetNewsAsync(articleId);
                _memoryCache.Set(cacheKey, hackerNewsArticle, TimeSpan.FromMinutes(10));
                return hackerNewsArticle;
            }
        }

        // TODO: make async
        public Task<IEnumerable<int>> GetTopStoriesAsync()
        {
            var cacheKey = "HackerNewsServiceCaching.GetTopStoriesAsync";
            if (_memoryCache.TryGetValue<IEnumerable<int>>(cacheKey, out var storyTask))
            {
                return Task.FromResult(storyTask);
            }
            else
            {
                // TODO: Read the timespan here from the config file
                var topStories = _innerHackerNewsService.GetTopStoriesAsync();
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
                // TODO: Read the timespan here from the config file
                var topStories = await _innerHackerNewsService.GetAllTopStoriesAsync();
                _memoryCache.Set(cacheKey, topStories, TimeSpan.FromMinutes(10));
                return topStories;
            }
        }
    }
}
