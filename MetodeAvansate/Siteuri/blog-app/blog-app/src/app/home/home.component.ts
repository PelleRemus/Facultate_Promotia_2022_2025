import { Component } from '@angular/core';
import { Article } from '../models/article';
import { ArticlesService } from '../services/articles.service';
import { GlobalService } from '../services/global.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  articles: Article[] = [];
  isLoading: boolean = true;

  constructor(private articlesService: ArticlesService, public service: GlobalService) {
    this.service.searchChange.subscribe(value => this.getArticles(value));
    this.getArticles('');
  }

  getArticles(search: string) {
    this.isLoading = true;
    this.articlesService.getArticles(search).subscribe(async (res) => {
      await this.service.delay(500);
      this.isLoading = false;
      this.articles = res;
    })
  }
}
