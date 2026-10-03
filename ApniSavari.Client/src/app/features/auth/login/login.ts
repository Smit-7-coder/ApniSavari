import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth';
import { LoginRequest } from '../../../core/models/login-request';
import { Router } from '@angular/router';

@Component({
  imports: [FormsModule, RouterLink],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {
  loginData : LoginRequest = {
    email : '',
    password : ''
  };

  message: string = '';
  errorMessage: string = '';
  isLoading: boolean = false;

  authService = inject(AuthService);
  router = inject(Router);

  login(): void{
    this.message = '';
    this.errorMessage = '';
    this.isLoading = true;

    this.authService.login(this.loginData).subscribe({
      next:(response)=>{
        this.isLoading = false;

        console.log('Login response:', response);
        console.log('JWT Token:', response.token);
        this.message = 'Login Successfull!';
        console.log(response);
        this.router.navigate(['/customer/dashboard']);


        localStorage.setItem('token', response.token);
      },
      error:(error)=>{
        this.isLoading = false;
        this.errorMessage = error.error?.message ?? 'Login failed.';
      }
    })
  }

 
}
