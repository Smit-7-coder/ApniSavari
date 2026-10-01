import { Routes } from '@angular/router';
import { Register } from './features/auth/register/register';
import { Login } from './features/auth/login/login';
import { CustomerLayout } from './features/customer/customer-layout/customer-layout';
import { CustomerDashboard } from './features/customer/customer-dashboard/customer-dashboard';
import { authGuard } from './core/guards/auth-guard';

export const routes: Routes = [
  {
    path:'',
    redirectTo:'login',
    pathMatch:'full'
  },
  {
    path:'login', 
    component: Login
  },
  {
    path: 'register',
    component: Register
  },
  {
    path: 'customer',
    component: CustomerLayout,
    canActivate: [authGuard],
    children: [
      {
         path: '', 
         redirectTo: 'dashboard', 
         pathMatch: 'full'
      },
      {
        path: 'dashboard',
        component: CustomerDashboard
      }
    ]
  }
];
