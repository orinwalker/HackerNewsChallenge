using HackerNewsModernUI.Controllers;
using HackerNewsModernUI.Models;
using HackerNewsModernUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerNewsTests
{
    public class HackerNewsServiceTests
    {
        private readonly ILogger _logger;

        public HackerNewsServiceTests()
        {
            var serviceProvider = new ServiceCollection()
               .AddLogging()
               .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            _logger = factory.CreateLogger<HackerNewsController>();
        }

        

        [Fact]
        public void TestLogger()
        {
            _logger.LogInformation("xyz");
            Assert.True(true);
        }

        [Fact]
        public async void HackerNewsServiceTest()
        {
            // Arrange 
            var articleId = 8863;
            var mockRepo = new Mock<IHackerNewsService>();
            mockRepo.Setup(repo => repo.GetNewsAsync(articleId))
                .Returns(GetMockHackerNewsArticle);
            var hackerNewsService = new HackerNewsService();
            var result = await hackerNewsService.GetNewsAsync(articleId);
            // Act

            mockRepo.Verify();


            //    //mockRepo.Setup(repo =>
            //    //repo.GetAllAsync()).ReturnsAsync(employeeDetail.ToList());
            //    //Task<HackerNewsArticle> output = null;
            //    //output = mockRepo.Setup(repo => repo.GetNewsAsync(articleId)); //.ReturnsAsync(output);
            //mockRepo.Setup(repo => repo.GetNewsAsync(
            //    It.IsAny<int>()))
            //    .ReturnsAsync((int i) =>
            //    hackerArticles.SingleOrDefault(x => x.Id == i));

            // Assert
            //var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            //Assert.Null(redirectToActionResult.ControllerName);
            //Assert.Equal("Index", redirectToActionResult.ActionName);



            // mockRepo.SetupAllProperties();
            //.ReturnsAsync(GetMockHackerNewsArticle());

            //     mockRepo.Setup(repo => repo.ListAsync())
            //.ReturnsAsync(GetTestSessions());

            //    mockRepo.Setup(repo => repo.GetEmployeeDetailById(
            //       It.IsAny<int>())).ReturnsAsync((int i) =>
            //       employeeDetail.SingleOrDefault(x => x.EId == i));

            //    mockRepo.Setup(repo => repo.Insert(It.IsAny<EmployeeDetail>()))
            //    .Callback((EmployeeDetail employeeDetails) =>
            //    {
            //        employeeDetails.EId = employeeDetail.Count() + 1;
            //        employeeDetail.Add(employeeDetails);
            //    }).Verifiable();

            //    mockRepo.Setup(repo => repo.Delete(It.IsAny<EmployeeDetail>()))
            //    .Callback((EmployeeDetail employeeDetails) =>
            //    {
            //        employeeDetails.EId = employeeDetail.Count() - 1;
            //        employeeDetail.Remove(employeeDetails);
            //    }).Verifiable();


            //_mapper = WebAPI.Mapper.Mapper.GetMapper();

            //_service = new HackerNewsService(mockRepo.Object);
        }

        private Task<HackerNewsArticle> GetMockHackerNewsArticle()
        {
            var hackerNewsArticle = new HackerNewsArticle
            {
                By = "ORIN: dhouston",
                Descendants = 71,
                Id = 8863,
                // Kids = [ 8952, 9224, 8917, 8884, 8887, 8943, 8869, 8958, 9005, 9671, 8940, 9067, 8908, 9055, 8865, 8881, 8872, 8873, 8955, 10403, 8903, 8928, 9125, 8998, 8901, 8902, 8907, 8894, 8878, 8870, 8980, 8934, 8876 ],
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
