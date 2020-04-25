﻿using HackerNewsModernUI.Models;
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

        // TODO: Inject Logger into constructor

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

                // TODO: do I need this?
                response.EnsureSuccessStatusCode();    // Throw if not a success code.
                
                if (response.IsSuccessStatusCode)
                    newsArticle = await response.Content.ReadAsAsync<HackerNewsArticle>();
            }
            catch (Exception ex)
            {
                // TODO: log exeception
            }
            return newsArticle;
        }

        public async Task<IEnumerable<int>> GetTopStoriesAsync()
        {
            // TODO: get this from config file
            var apiUrl = "https://hacker-news.firebaseio.com/v0/topstories.json";

            List<int> hackerItem = null;
            try
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using HttpResponseMessage response = await _client.GetAsync(apiUrl);

                // TODO: do I need this?
                response.EnsureSuccessStatusCode();    // Throw if not a success code.

                if (response.IsSuccessStatusCode)
                    hackerItem = await response.Content.ReadAsAsync<List<int>>();
            }
            catch (Exception ex)
            {
                // TODO: log exeception
            }
            return hackerItem;
        }
    }
}
