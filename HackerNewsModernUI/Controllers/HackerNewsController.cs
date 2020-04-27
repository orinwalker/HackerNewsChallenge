using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackerNewsModernUI.Models;
using HackerNewsModernUI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HackerNewsModernUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {
        private readonly ILogger<HackerNewsController> _logger;
        private readonly IHackerNewsCachedService _hackerNews;

        public HackerNewsController(ILogger<HackerNewsController> logger, IHackerNewsCachedService hackerNews)
        {
            _logger = logger;
            _hackerNews = hackerNews;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        // TODO: Can this be an ActionResult?
        // GET: api/HackerNews
        //[HttpGet]
        //public async Task<IEnumerable<IHackerNewsArticle>> Get()
        //{
        //    var newsItems = new List<IHackerNewsArticle>();
        //    var ts = await _hackerNews.GetTopStoriesAsync();
        //    var hackerItems = ts.ToList();
        //    if (hackerItems.Count > 0)
        //    {
        //        foreach (var id in hackerItems)
        //        {
        //            var r = await _hackerNews.GetNewsAsync(id);
        //            newsItems.Add(r);
        //        }
        //    }

        //    return newsItems;
        //}

        [HttpGet]
        public async Task<IEnumerable<IHackerNewsArticle>> Get()
        {
            //var newsItems = new List<IHackerNewsArticle>();
            //var ts = await _hackerNews.GetTopStoriesAsync();
            //var hackerItems = ts.ToList();
            //if (hackerItems.Count > 0)
            //{
            //    foreach (var id in hackerItems)
            //    {
            //        var r = await _hackerNews.GetNewsAsync(id);
            //        newsItems.Add(r);
            //    }
            //}

            //return newsItems;

            var result = await _hackerNews.GetAllTopStoriesAsync();
            return result;
        }

        // GET: api/HackerNews/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HackerNews
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HackerNews/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
