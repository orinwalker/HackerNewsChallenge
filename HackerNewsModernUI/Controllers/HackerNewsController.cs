using System.Collections.Generic;
using System.Threading.Tasks;
using HackerNewsModernUI.Models;
using HackerNewsModernUI.Services;
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

        // GET: api/HackerNews/
        [HttpGet]
        public async Task<IEnumerable<IHackerNewsArticle>> Get()
        {
            var result = await _hackerNews.GetAllTopStoriesAsync();
            return result;
        }

        // GET: api/HackerNews/SearchTerm
        [HttpGet("{searchTerm}", Name = "Get")]
        public async Task<IEnumerable<IHackerNewsArticle>> Get(string searchTerm)
        {
            var result = await _hackerNews.SearchTopStoriesAsync(searchTerm);
            return result;
        }
    }
}
