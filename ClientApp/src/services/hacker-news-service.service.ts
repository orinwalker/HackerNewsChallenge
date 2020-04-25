import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HackerNews } from '../app/interfaces/hacker-news';

@Injectable({
  providedIn: 'root'
})
export class HackerNewsServiceService {

  private baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  // TODO: Need better error handling here
  public getHackerNewsOLD() {
    return this.httpClient.get<HackerNews[]>(this.baseUrl+ 'api/hackernews').subscribe(result => {
      //this.hackerNews = result;
      console.log('hackerNews: ' + result);
      //return result;
    }, error => console.error(error));
  }

  public getHackerNews() {
    return this.httpClient.get<HackerNews[]>(this.baseUrl + 'api/hackernews');
  }
}
