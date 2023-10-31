import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Article } from '../models/article';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {

  baseURL: string = "https://localhost:7107/";
  apiPath: string = "api/articles/";

  constructor(private httpClient: HttpClient) { }

  getArticles(): Observable<Article[]> {
    return this.httpClient.get<Article[]>(`${this.baseURL}${this.apiPath}`);
  }
}
