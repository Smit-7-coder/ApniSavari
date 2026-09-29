import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import{inject} from '@angular/core';
import{ AuthService } from '../../../core/services/auth';
import { LoginRequest } from '../../../core/models/login-request';

@Component({
  imports: [FormsModule],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {
  LoginData : LoginRequest = {
    email : '',
    password : ''
  };

  message: string = '';
  errorMessage: string = '';

  authService = inject(AuthService);

  login(): void{
    this.message = '';
    this.errorMessage = '';

    this.authService.login(this.LoginData).subscribe({
      next:(response)=>{
        console.log('Login response:', response);
        console.log('JWT Token:', response.token);
        this.message = 'Login Successfull!';
        console.log(response);

        localStorage.setItem('token', response.token);
      },
      error:(error)=>{
        this.errorMessage = error.error?.message ?? 'Login failed.';
      }
    })
  }
}
