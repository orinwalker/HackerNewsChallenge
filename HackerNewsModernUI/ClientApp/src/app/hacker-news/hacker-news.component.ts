import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HackerNewsServiceService } from '../../services/hacker-news-service.service';
import { HackerNews } from '../interfaces/hacker-news';

@Component({
  selector: 'app-hacker-news',
  templateUrl: './hacker-news.component.html',
  styleUrls: ['./hacker-news.component.css']
})

 // TODO: Implement error handling for these methods
export class HackerNewsComponent implements OnInit {

  public hackerNews: HackerNews[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private hackerNewsService: HackerNewsServiceService) {
  }

  ngOnInit() {
     console.log('ngOnInit called, fetching news');
    this.hackerNewsService.getHackerNews().subscribe((data) => {
      this.hackerNews = data;
    });
  }

  searchHackerNews(searchTerm) {
    console.log('searchHackerNews called with search term: ' + searchTerm);
    this.hackerNewsService.searchHackerNews(searchTerm).subscribe((data) => {
      // console.log('data received from search: ' + data);
      this.hackerNews = data;
    });
  }

  reset() {
    console.log('reset called');
    this.hackerNews = null;
    this.hackerNewsService.getHackerNews().subscribe((data) => {
      // console.log('data received after reset: ' + data);
      this.hackerNews = data;
    });
  }

}
