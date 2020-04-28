using HackerNewsModernUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
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
            var logger = GetLogger();
            var hackerNewsService = new HackerNewsService(logger);

            // Act
            var rv = await hackerNewsService.GetNewsAsync(articleId);
            
            // Assert
            Assert.Equal(8863, rv.Id);
            Assert.Equal("dhouston", rv.By);
        }

        [Fact]
        public async void HackerNewsService_GetTopArticleIdsAsync()
        {
            // Arrange 
            var logger = GetLogger();
            var hackerNewsService = new HackerNewsService(logger);

            // Act
            var rv = await hackerNewsService.GetTopArticleIdsAsync();
            int[] result = rv.ToArray();

            // Assert
            var type1 = Assert.IsType<int[]>(result);
            Assert.True(result.Count() > 0);
        }

        private ILogger<HackerNewsService> GetLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var logger = factory.CreateLogger<HackerNewsService>();
            return logger;
        }
    }
}
