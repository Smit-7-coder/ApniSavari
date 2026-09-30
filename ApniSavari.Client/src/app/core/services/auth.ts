import {Injectable} from '@angular/core';
import{HttpClient} from '@angular/common/http';
import {inject} from '@angular/core';
import {Observable} from 'rxjs';
import {RegisterRequest} from '../models/register-request';
import {AuthResponse} from '../models/auth-response';
import { LoginRequest } from '../models/login-request';


@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private apiURL = 'https://localhost:7274/api/Auth';
    http = inject(HttpClient);

    register(request: RegisterRequest): Observable<AuthResponse>{
        return this.http.post<AuthResponse>(
            `${this.apiURL}/register`, request
        );
    }

    login(request: LoginRequest): Observable<AuthResponse>{
        return this.http.post<AuthResponse>(
            `${this.apiURL}/login`,request
        );
    }


}