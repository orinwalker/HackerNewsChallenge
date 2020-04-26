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

}
