import { Component } from '@angular/core';
import { Router, RouterLinkActive, RouterLink, RouterOutlet} from '@angular/router';
import { inject } from '@angular/core';
import { signal } from '@angular/core';

@Component({
  imports: [RouterLink, RouterLinkActive, RouterOutlet],
  selector: 'app-customer-layout',
  styleUrl: './customer-layout.css',
  templateUrl: './customer-layout.html',
})
export class CustomerLayout {
  isLoggedIn = signal<boolean>(!!localStorage.getItem('token'));
  menuOpen = signal<boolean>(false);
  router = inject(Router);
  currentYear = new Date().getFullYear();

  logout(): void {
    localStorage.removeItem('token');
    this.isLoggedIn.set(false);
    this.menuOpen.set(false);
    this.router.navigate(['/login']);
  }

  closeMenu(): void{
    this.menuOpen.set(false);
  }

  toggleMenu(): void{
    this.menuOpen.update(value => !value)
  }
}
