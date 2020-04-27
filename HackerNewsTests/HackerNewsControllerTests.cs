using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackerNewsModernUI.Controllers;
using HackerNewsModernUI.Models;
using HackerNewsModernUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HackerNewsTests
{
    public class HackerNewsControllerTests
    {
        [Fact]
        public void TestController()
        {
            // Arrange 
            var mockRepo = new Mock<IHackerNewsCachedService>();
            mockRepo.Setup(repo => repo.GetAllTopStoriesAsync())
                .Returns(GetMockHackerNewsArticles());
            var logger = GetLogger();
            var controller = new HackerNewsController(logger, mockRepo.Object);

            // Act
            var rv = controller.Get();
            var result = rv.Result.ToArray(); // TODO: combine with line above

            // Assert
            var type = Assert.IsType<Task<IEnumerable<IHackerNewsArticle>>>(rv); // TODO: change this to result
            Assert.Equal(2, result.Count());
            Assert.Equal(8863, result[0].Id);
            Assert.Equal("My YC app: Dropbox - Throw away your USB drive", result[0].Title);
            Assert.Equal(8864, result[1].Id);
            Assert.Equal("https://rust-analyzer.github.io/blog/2020/04/20/first-release.html", result[1].Url);
        }

        private ILogger<HackerNewsController> GetLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<HackerNewsController>();
            return logger;
        }

        private Task<IEnumerable<IHackerNewsArticle>> GetMockHackerNewsArticles()
        {
            var hackerArticles = new List<IHackerNewsArticle>()
              {
               new HackerNewsArticle
               {
                     By = "dhouston",
                     Descendants = 71,
                     Id = 8863,
                     Score = 111,
                     Time = 1175714200,
                     Title = "My YC app: Dropbox - Throw away your USB drive",
                     Type = "story",
                     Url = "http://www.getdropbox.com/u/2/screencast.html"
                },
               new HackerNewsArticle
                {
                     By = "groar",
                     Descendants = 6,
                     Id = 8864,
                     Score = 234,
                     Time = 1154424200,
                     Title = "YOLOv4: Optimal Speed and Accuracy of Object Detection",
                     Type = "story",
                     Url = "https://rust-analyzer.github.io/blog/2020/04/20/first-release.html"
                  }
               };

            return Task.FromResult(hackerArticles.AsEnumerable());
        }
    }
}
