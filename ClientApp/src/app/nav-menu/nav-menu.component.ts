import { Component, Inject } from '@angular/core';
import { AuthService } from '../auth/AuthService';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent {
  isExpanded = false;
  public base: string = '';

  constructor(
    @Inject('BASE_URL') baseUrl: string,
    public authService: AuthService
  ) {
    this.base = baseUrl;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
