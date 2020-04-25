import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HackerNewsServiceService } from '../../services/hacker-news-service.service';
import { HackerNews } from '../interfaces/hacker-news';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public hackerNews: HackerNews[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private hackerNewsService: HackerNewsServiceService) {
  }

  ngOnInit() {
    // TODO: fix up error handling
    this.hackerNewsService.getHackerNews().subscribe((data) => {
      this.hackerNews = data;
    });
  }
}

// TODO: if time then this could be useful
//https://stackoverflow.com/questions/847185/convert-a-unix-timestamp-to-time-in-javascript

// UtcDateTimes look like this
// 2020-04-24T21:15:28Z

// this also might be useful
//console.log(new Date(1549312452 * 1000).toISOString().slice(0, 19).replace('T', ' '));

// this code could be put into a custom pipe to display the date times (would use time rather than utcDateTime)
//var timestamp = 1293683278;
//var date = new Date(timestamp * 1000);
//var iso = date.toISOString().match(/(\d{2}:\d{2}:\d{2})/)
//alert(iso[1]);
