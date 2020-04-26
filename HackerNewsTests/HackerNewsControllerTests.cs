using AutoMapper;
using HackerNewsModernUI.Controllers;
using HackerNewsModernUI.Models;
using HackerNewsModernUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerNewsTests
{
    public class HackerNewsServiceTest
    {
        private readonly HackerNewsService _service;
        private readonly IMapper _mapper;

        public HackerNewsServiceTest()
        {
            var mockRepo = new Mock<IHackerNewsService>();
            IList<HackerNewsArticle> employeeDetail = new List<HackerNewsArticle>()
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

        //    //mockRepo.Setup(repo =>
        //    //repo.GetAllAsync()).ReturnsAsync(employeeDetail.ToList());

        //    var articleId = 8863;
        //    //Task<HackerNewsArticle> output = null;
        //    //output = mockRepo.Setup(repo => repo.GetNewsAsync(articleId)); //.ReturnsAsync(output);

        //    mockRepo.Setup(repo => repo.GetNewsAsync(
        //It.IsAny<int>())).ReturnsAsync((int i) =>
        //employeeDetail.SingleOrDefault(x => x.EId == i));

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
            
        //    mockRepo.SetupAllProperties();
        //    _mapper = WebAPI.Mapper.Mapper.GetMapper();
        //    _service = new EmployeeDetailService(mockRepo.Object, _mapper);
        }
    }


    public class HackerNewsControllerTests
    {
        // TODO: Pull in the ILogger 
        private readonly ILogger _logger;

        // TODO: Create this using MOQ
        //private readonly _hackerNewsService = null;

        // TODO: this needs created
        //private readonly _contextMock = null;

        public HackerNewsControllerTests()
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

        ////Arrange
        //var mockLeagueService = new MockLeagueService().MockGetAll(new List<League>());

        //var controller = new LeagueController(mockLeagueService.Object);

        ////Act
        //var result = controller.Index();

        ////Assert
        //Assert.IsAssignableFrom<ViewResult>(result);
        // mockLeagueService.VerifyGetAll(Times.Once());



        [Fact]
        public async Task Get_order_detail_success()
        {

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

        }
    }
}
