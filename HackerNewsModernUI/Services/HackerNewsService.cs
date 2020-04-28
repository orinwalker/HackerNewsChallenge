using HackerNewsModernUI.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HackerNewsModernUI.Services
{
    public class HackerNewsService: IHackerNewsService
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly ILogger _logger;

        public HackerNewsService(ILogger<HackerNewsService> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<IHackerNewsArticle>> SearchTopStoriesAsync(string searchTerm)
        {
            var response = await GetAllTopStoriesAsync();
            var topStories = response.ToList();
            var searchResult = topStories.Where(s => s.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            return searchResult;
        }

        public async Task<HackerNewsArticle> GetNewsAsync(int articleId)
        {
            // TODO: get this from config file
            var urlTemplate = "https://hacker-news.firebaseio.com/v0/item/{0}.json";
            var apiUrl = string.Format(urlTemplate, articleId);

            HackerNewsArticle newsArticle = null;
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using HttpResponseMessage response = await _client.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();    // Throw if not a success code.
                
                if (response.IsSuccessStatusCode)
                    newsArticle = await response.Content.ReadAsAsync<HackerNewsArticle>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GetNewsAsync, with articleId: " + articleId);
            }
            return newsArticle;
        }

        public async Task<IEnumerable<IHackerNewsArticle>> GetAllTopStoriesAsync() 
        {
            var newsItems = new List<IHackerNewsArticle>();
            var ts = await this.GetTopArticleIdsAsync();
            var hackerItems = ts.ToList();
            if (hackerItems.Count > 0)
            {
                foreach (var id in hackerItems)
                {
                    var r = await this.GetNewsAsync(id);
                    newsItems.Add(r);
                }
            }
            return newsItems;
        }

        public async Task<IEnumerable<int>> GetTopArticleIdsAsync()
        {
            // TODO: get this from config file
            var apiUrl = "https://hacker-news.firebaseio.com/v0/topstories.json";

            List<int> hackerItem = null;
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using HttpResponseMessage response = await _client.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();    // Throw if not a success code.

                if (response.IsSuccessStatusCode)
                    hackerItem = await response.Content.ReadAsAsync<List<int>>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GetTopStoriesAsync");
            }
            return hackerItem;
        }
    }
}
