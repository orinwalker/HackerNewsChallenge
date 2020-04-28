export interface HackerNews {
  by: string;
  descendants: number;
  id: number;
  kids: number[] | null;
  score: number;
  time: number;
  utcDateTime: string;
  howLongAgo: string;
  title: null | string;
  type: string;
  url: null | string;
}
