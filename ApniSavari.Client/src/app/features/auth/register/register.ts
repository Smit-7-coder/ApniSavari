import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../../core/services/auth';
import { RegisterRequest } from '../../../core/models/register-request';
import { inject } from '@angular/core';


@Component({
  imports: [FormsModule],
  selector: 'app-register',
  styleUrl: './register.css',
  templateUrl: './register.html',
})
export class Register {
  registerData: RegisterRequest = {
    fullName: '',
    email: '',
    phoneNumber: '',
    password: '',
    confirmPassword: ''
  };

  message: string = '';
  errorMessage: string = '';

  authService = inject(AuthService);

  register(): void{
    this.message = '';
    this.errorMessage = '';

    this.authService.register(this.registerData).subscribe({
      next: (response) =>{
        this.message = 'Registration Successfull!';
        console.log(response);
      },
      error: (error)=>{
        this.errorMessage = error.error?.message ?? 'Registration failed.';
      }
    });
  }
}
