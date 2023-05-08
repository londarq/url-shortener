import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// npmimport { Clipboard } from '@angular/cdk/clipboard';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public urls: Url[] = [];
  public base: string = '';

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
    // private clipboard: Clipboard
  ) {
    http.get<Url[]>(baseUrl + 'api/urls').subscribe({
      next: (result) => {
        this.urls = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
    this.base = baseUrl;
  }

  getShortUrl(url: Url): string {
    return `${this.base}u/${url.shortUrl}`;
  }

  // copyToClipboard(url: string): void {
  //   this.clipboard.copy(url);
  // }
}

interface Url {
  id: number;
  targetUrl: string;
  shortUrl: string;
  userName: string;
}
