import { TestBed } from '@angular/core/testing';

import { HackerNewsServiceService } from './hacker-news-service.service';

describe('HackerNewsServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HackerNewsServiceService = TestBed.get(HackerNewsServiceService);
    expect(service).toBeTruthy();
  });
});
