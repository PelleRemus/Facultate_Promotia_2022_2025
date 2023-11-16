import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseURL: string = "https://localhost:7107/";
  apiPath: string = "api/users/";

  constructor(private httpClient: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.baseURL}${this.apiPath}`);
  }

  getOneUser(id: number): Observable<User> {
    return this.httpClient.get<User>(`${this.baseURL}${this.apiPath}${id}`);
  }

  postUser(user: User): Observable<User> {
    return this.httpClient.post<User>(`${this.baseURL}${this.apiPath}`, user);
  }

  editUser(id: number, user: User): Observable<any> {
    return this.httpClient.put<any>(`${this.baseURL}${this.apiPath}${id}`, user);
  }

  deleteUser(id: number): Observable<User> {
    return this.httpClient.delete<User>(`${this.baseURL}${this.apiPath}${id}`);
  }
}
