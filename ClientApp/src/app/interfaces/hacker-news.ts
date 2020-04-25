export interface HackerNews {
  by: string;
  descendants: number;
  id: number;
  kids: number[] | null;
  score: number;
  time: number;
  // TODO: determine if this is useful
  utcDateTime: string;
  howLongAgo: string;
  title: null | string;
  type: string;
  url: null | string;
}
