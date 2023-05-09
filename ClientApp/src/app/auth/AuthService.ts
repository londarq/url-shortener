import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<boolean> {
    return this.http.post<any>('account/login', { username, password }).pipe(
      map((response) => {
        const token = response.token;
        if (token) {
          localStorage.setItem('access_token', token);
          return true;
        } else {
          return false;
        }
      })
    );
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('access_token');

    if (this.jwtHelper.isTokenExpired(token)) {
      this.logout();
      return false;
    }

    return true;
  }

  public getUserRoles(): string[] {
    const token = localStorage.getItem('access_token');

    if (token !== null) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      return decodedToken.role;
    }

    return [];
  }

  public getUserName(): string {
    const token = localStorage.getItem('access_token');

    if (token !== null) {
      const decodedToken = this.jwtHelper.decodeToken(token);
      return decodedToken.username;
    }

    return '';
  }

  logout(): void {
    localStorage.removeItem('access_token');
  }
}
