import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Clipboard } from '@angular/cdk/clipboard';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
})
export class FetchDataComponent {
  public urls: Url[] = [];
  public base: string = '';

  public shortUrl: string = '';
  public longUrl: string = '';
  public errorMessage: string = '';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private clipboard: Clipboard
  ) {
    this.base = baseUrl;
  }

  ngOnInit() {
    this.loadUrls();
  }

  loadUrls() {
    this.http.get<Url[]>('/api/urls').subscribe({
      next: (result) => {
        this.urls = result.reverse();
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  deleteUrl(id: number) {
    this.http.delete(`/api/urls/${id}`).subscribe(() => {
      this.loadUrls();
    });
  }

  onAddUrl() {
    this.http
      .post<Url>(
        '/api/urls',
        { url: this.longUrl },
        {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
          }),
        }
      )
      .subscribe({
        next: (result) => {
          if (this.urls.find((u) => u.targetUrl === this.longUrl)) {
            this.errorMessage = 'URL already exists';
          } else {
            this.longUrl = '';
            this.shortUrl = this.getShortUrl(result);
            this.errorMessage = '';
            this.loadUrls();
          }
        },
        error: (error) => {
          console.error(error);
          this.errorMessage =
            'Error occured, url may be invalid. Note, that it must start with https://';
        },
      });
  }

  getShortUrl(url: Url): string {
    return `${this.base}u/${url.shortUrl}`;
  }

  copyToClipboard(url: string): void {
    this.clipboard.copy(url);
  }
}

interface Url {
  id: number;
  targetUrl: string;
  shortUrl: string;
  userName: string;
}
