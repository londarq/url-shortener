import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Url } from '../url';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-short-url-info',
  templateUrl: './short-url-info.component.html',
})
export class ShortUrlInfoComponent {
  url: Url | undefined;

  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');

    this.http.get<Url>('/api/urls/' + id).subscribe({
      next: (result) => {
        this.url = result;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
