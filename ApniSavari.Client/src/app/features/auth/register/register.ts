import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

import { AuthService } from '../../../core/services/auth';
import { RegisterRequest } from '../../../core/models/register-request';

@Component({
  selector: 'app-register',
  imports: [
    FormsModule,
    RouterLink
  ],
  templateUrl: './register.html',
  styleUrl: './register.css'
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
  isLoading: boolean = false;

  authService = inject(AuthService);


  register(): void {

    this.message = '';
    this.errorMessage = '';
    this.isLoading = true;

    this.authService.register(this.registerData).subscribe({

      next: (response) => {

        this.isLoading = false;

        console.log('Registration response:', response);

        this.message =
          'Registration successful! You can now login.';

      },

      error: (error) => {

        this.isLoading = false;

        console.error('Registration error:', error);

        this.errorMessage =
          error.error?.message ??
          'Registration failed. Please try again.';

      }

    });

  }
}