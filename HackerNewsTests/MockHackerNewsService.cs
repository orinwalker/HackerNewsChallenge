using HackerNewsModernUI.Models;
using HackerNewsModernUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HackerNewsTests
{
    // public class MockHackerNewsService: IHackerNewsService
    // {
    //     private static readonly HttpClient _client = new HttpClient();

    //     // TODO: Inject Logger into constructor

    //     public Task<IEnumerable<IHackerNewsArticle>> GetAllTopStoriesAsync()
    //     {
    //         // TODO: this needs implemented
    //         throw new NotImplementedException();
    //     }


    //     public async Task<HackerNewsArticle> GetNewsAsync(int articleId)
    //     {
    //         var newsArticle = await GetMockHackerNewsArticle(articleId);
    //         return newsArticle;
    //     }

    //     private Task<HackerNewsArticle> GetMockHackerNewsArticle(int articleId)
    //     {
    //         var hackerNewsArticle = new HackerNewsArticle
    //         {
    //             By = "dhouston",
    //             Descendants = 71,
    //             Id = 8863,
    //             // Kids = [ 8952, 9224, 8917, 8884, 8887, 8943, 8869, 8958, 9005, 9671, 8940, 9067, 8908, 9055, 8865, 8881, 8872, 8873, 8955, 10403, 8903, 8928, 9125, 8998, 8901, 8902, 8907, 8894, 8878, 8870, 8980, 8934, 8876 ],
    //             Score = 111,
    //             Time = 1175714200,
    //             Title = "My YC app: Dropbox - Throw away your USB drive",
    //             Type = "story",
    //             Url = "http://www.getdropbox.com/u/2/screencast.html"
    //         };

    //         return Task.FromResult(hackerNewsArticle);
    //     }

    //     private Task<IEnumerable<int>> GetMockTopStories()
    //     {
    //         var list = new List<int>();
    //         list.Add(1);
    //         list.Add(2);
    //         list.Add(3);
    //         return Task.FromResult(list.AsEnumerable());
    //     }

    //     public async Task<IEnumerable<int>> GetTopStoriesAsync()
    //     {
    //         var result = await GetMockTopStories();
    //         return result;
    //     }
    // }
}
