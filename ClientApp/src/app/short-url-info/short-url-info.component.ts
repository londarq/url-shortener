import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Url } from '../url';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../auth/AuthService';

@Component({
  selector: 'app-short-url-info',
  templateUrl: './short-url-info.component.html',
})
export class ShortUrlInfoComponent {
  url: Url | undefined;
  isAuthenticated: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private http: HttpClient,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.isAuthenticated = this.authService.isAuthenticated();

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
