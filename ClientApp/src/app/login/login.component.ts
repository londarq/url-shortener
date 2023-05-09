import { Component } from '@angular/core';
import { AuthService } from '../auth/AuthService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(public authService: AuthService, private router: Router) {}

  onSubmit() {
    this.authService.login(this.username, this.password).subscribe({
      next: (result) => {
        this.router.navigate(['/']);
      },
      error: (error) => {
        this.errorMessage = 'Invalid username or password';
      },
    });
  }
}
