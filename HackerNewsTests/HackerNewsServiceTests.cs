using HackerNewsModernUI.Controllers;
using HackerNewsModernUI.Models;
using HackerNewsModernUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerNewsTests
{
    public class HackerNewsServiceTests
    {
        [Fact]
        public async void HackerNewsService_GetNewsAsync_ById()
        {
            // Arrange 
            var articleId = 8863;
            var mockRepo = new Mock<IHackerNewsService>();
            mockRepo.Setup(repo => repo.GetNewsAsync(articleId))
                .Returns(GetMockHackerNewsArticle);
            var hackerNewsService = new HackerNewsService();

            // Act
            var rv = await hackerNewsService.GetNewsAsync(articleId);
            
            // Assert
            Assert.Equal(8863, rv.Id);
            Assert.Equal("dhouston", rv.By);
        }

        public async void HackerNewsService_GetTopArticleIds()
        {
            // Arrange 
            var mockRepo = new Mock<IHackerNewsService>();
            mockRepo.Setup(repo => repo.GetTopStoriesAsync())
                .Returns(GetMockTopArticleIds);
            var hackerNewsService = new HackerNewsService();

            // Act
            var rv = await hackerNewsService.GetTopStoriesAsync();
            var result = rv.ToArray();
            // Assert
            Assert.Equal(7463, result[0]);
            Assert.Equal(7464, result[1]);
            Assert.Equal(7465, result[2]);
        }

        private Task<IEnumerable<int>> GetMockTopArticleIds()
        {
            var list = new List<int>();
            list.Add(7463);
            list.Add(7464);
            list.Add(7465);
            return Task.FromResult(list.AsEnumerable());
        }
        
        private Task<HackerNewsArticle> GetMockHackerNewsArticle()
        {
            var hackerNewsArticle = new HackerNewsArticle
            {
                By = "dhouston",
                Descendants = 71,
                Id = 8863,
                Score = 111,
                Time = 1175714200,
                Title = "ORIN: My YC app: Dropbox - Throw away your USB drive",
                Type = "story",
                Url = "http://www.getdropbox.com/u/2/screencast.html"
            };
            return Task.FromResult(hackerNewsArticle);
        }
    }
}
