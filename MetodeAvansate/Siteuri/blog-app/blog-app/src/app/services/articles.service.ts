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

  getArticles(search: string): Observable<Article[]> {
    return this.httpClient.get<Article[]>(`${this.baseURL}${this.apiPath}?search=${search}`);
  }

  getOneArticle(id: number): Observable<Article> {
    return this.httpClient.get<Article>(`${this.baseURL}${this.apiPath}${id}`);
  }

  postArticle(article: Article): Observable<Article> {
    return this.httpClient.post<Article>(`${this.baseURL}${this.apiPath}`, article);
  }

  editArticle(id: number, article: Article): Observable<any> {
    return this.httpClient.put<any>(`${this.baseURL}${this.apiPath}${id}`, article);
  }

  deleteArticle(id: number): Observable<Article> {
    return this.httpClient.delete<Article>(`${this.baseURL}${this.apiPath}${id}`);
  }
}
