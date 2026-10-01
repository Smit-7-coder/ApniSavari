import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet} from '@angular/router';
import { inject } from '@angular/core';

@Component({
  imports: [RouterLink, RouterOutlet],
  selector: 'app-customer-layout',
  styleUrl: './customer-layout.css',
  templateUrl: './customer-layout.html',
})
export class CustomerLayout {
  router = inject(Router);

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
