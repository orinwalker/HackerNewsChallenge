import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HackerNewsServiceService } from '../../services/hacker-news-service.service';
import { HackerNews } from '../interfaces/hacker-news';

@Component({
  selector: 'app-hacker-news',
  templateUrl: './hacker-news.component.html',
  styleUrls: ['./hacker-news.component.css']
})
export class HackerNewsComponent implements OnInit {

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

  searchHackerNews(searchTerm) {
    // TODO: fix up error handling
    console.log('searchHackerNews ' + searchTerm);
    this.hackerNewsService.searchHackerNews(searchTerm).subscribe((data) => {
      // console.log('data received from search: ' + data);
      this.hackerNews = data;
    });
  }

  reset() {
    // TODO: fix up error handling
    console.log('reset');
    this.hackerNewsService.getHackerNews().subscribe((data) => {
      // console.log('data received after reset: ' + data);
      this.hackerNews = data;
    });
  }

}
