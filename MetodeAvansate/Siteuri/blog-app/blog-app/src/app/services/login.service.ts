import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserLogin } from '../models/userLogin';
import { Token } from '../models/token';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseURL: string = "https://localhost:7107/";
  apiPath: string = "api/login/";

  constructor(private httpClient: HttpClient) { }

  login(userLogin: UserLogin): Observable<Token> {
    return this.httpClient.post<Token>(`${this.baseURL}${this.apiPath}`, userLogin);
  }
}
