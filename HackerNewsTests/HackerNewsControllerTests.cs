using AutoMapper;
using HackerNewsModernUI;
using HackerNewsModernUI.Controllers;
using HackerNewsModernUI.Models;
using HackerNewsModernUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerNewsTests
{
    //public class HackerNewsServiceTest
    //{
        //private readonly HackerNewsService _service;
        //private readonly IMapper _mapper;

       

       


    //}


    public class HackerNewsControllerTests
    {
        // TODO: Pull in the ILogger 
        private readonly ILogger _logger;

        // TODO: Create this using MOQ
        //private readonly _hackerNewsService = null;

        // TODO: this needs created
        //private readonly _contextMock = null;

        private static ILogger<HackerNewsController> GetLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            // TODO: I don't understand this code
            var logger = factory.CreateLogger<HackerNewsController>();
            return logger;
        }
      

        [Fact]
        public void TestLogger()
        {
            _logger.LogInformation("xyz");
            Assert.True(true);
        }

        [Fact]
        public void TestController()
        {
            // Arrange 
            //var articleId = 8863;
            //var mockRepo = new Mock<IHackerNewsService>();
            //mockRepo.Setup(repo => repo.GetNewsAsync(articleId))
            //    .Returns(GetMockHackerNewsArticle);
            //var hackerNewsService = new HackerNewsService();
            //var result = await hackerNewsService.GetNewsAsync(articleId);

            var mockRepo = new Mock<IHackerNewsCachedService>();
            mockRepo.Setup(repo => repo.GetAllTopStoriesAsync())
                .Returns(GetMockHackerNewsArticles());
            var logger = GetLogger();
            //string logger = "";
            var controller = new HackerNewsController(logger, mockRepo.Object);
            var result = controller.Get();

            // Assert
            var type = Assert.IsType<Task<IEnumerable<IHackerNewsArticle>>>(result);


            //var count = result.ToList().Count;
            //var res = Assert.

            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsType<StormSessionViewModel>(
            //    viewResult.ViewData.Model);
            //Assert.Equal("Test One", model.Name);
            //Assert.Equal(2, model.DateCreated.Day);
            //Assert.Equal(testSessionId, model.Id);
        }

        // Task<IEnumerable<IHackerNewsArticle>>
        private Task<IEnumerable<IHackerNewsArticle>> GetMockHackerNewsArticles()
        {
            var hackerArticles = new List<IHackerNewsArticle>()
              {
               new HackerNewsArticle
               {
                   By = "dhouston",
                     Descendants = 71,
                     Id = 8863,
                    // Kids = [ 8952, 9224, 8917, 8884, 8887, 8943, 8869, 8958, 9005, 9671, 8940, 9067, 8908, 9055, 8865, 8881, 8872, 8873, 8955, 10403, 8903, 8928, 9125, 8998, 8901, 8902, 8907, 8894, 8878, 8870, 8980, 8934, 8876 ],
                     Score = 111,
                     Time = 1175714200,
                     Title = "My YC app: Dropbox - Throw away your USB drive",
                     Type = "story",
                     Url = "http://www.getdropbox.com/u/2/screencast.html"
                },
               new HackerNewsArticle
                {
                     By = "dhouston",
                     Descendants = 71,
                     Id = 8863,
                     // Kids = [ 8952, 9224, 8917, 8884, 8887, 8943, 8869, 8958, 9005, 9671, 8940, 9067, 8908, 9055, 8865, 8881, 8872, 8873, 8955, 10403, 8903, 8928, 9125, 8998, 8901, 8902, 8907, 8894, 8878, 8870, 8980, 8934, 8876 ],
                     Score = 111,
                     Time = 1175714200,
                     Title = "My YC app: Dropbox - Throw away your USB drive",
                     Type = "story",
                     Url = "http://www.getdropbox.com/u/2/screencast.html"
                  }
               };

            return Task.FromResult(hackerArticles.AsEnumerable());
        }

        //private Task<HackerNewsArticle> GetMockHackerNewsArticles()
        //{
        //    var hackerNewsArticle = new HackerNewsArticle
        //    {
        //        By = "ORIN: dhouston",
        //        Descendants = 71,
        //        Id = 8863,
        //        // Kids = [ 8952, 9224, 8917, 8884, 8887, 8943, 8869, 8958, 9005, 9671, 8940, 9067, 8908, 9055, 8865, 8881, 8872, 8873, 8955, 10403, 8903, 8928, 9125, 8998, 8901, 8902, 8907, 8894, 8878, 8870, 8980, 8934, 8876 ],
        //        Score = 111,
        //        Time = 1175714200,
        //        Title = "ORIN: My YC app: Dropbox - Throw away your USB drive",
        //        Type = "story",
        //        Url = "http://www.getdropbox.com/u/2/screencast.html"
        //    };
        //    return Task.FromResult(hackerNewsArticle);
        //}

        ////Arrange
        //var mockLeagueService = new MockLeagueService().MockGetAll(new List<League>());

        //var controller = new LeagueController(mockLeagueService.Object);

        ////Act
        //var result = controller.Index();

        ////Assert
        //Assert.IsAssignableFrom<ViewResult>(result);
        // mockLeagueService.VerifyGetAll(Times.Once());



        //[Fact]
        //public async Task Get_order_detail_success()
        //{

        //Arrange
        //var fakeOrderId = "12";
        //var fakeOrder = GetFakeOrder();

        //...
        //var mockHackerNewsService = new MockHackerNewsService().MockGet();
        //Act
        //var hackerNewsController = new HackerNewsController(
        //    _logger,
        //    _hackerNewsService.Object);

        //hackerNewsController.ControllerContext.HttpContext = _contextMock.Object;
        //var result = await hackerNewsController.Get();

        //Assert
        //var viewResult = Assert.IsType<Task<IEnumerable<IHackerNewsArticle>>>(result);

        // TODO: Figure out how check if result is 'OK' (200 status code)
        //viewResult.Result
        //Assert.IsAssignableFrom<Order>(viewResult.ViewData.Model);

        //}
    }
}
