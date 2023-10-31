import { Component } from '@angular/core';
import { Article } from '../models/article';
import { ArticlesService } from '../services/articles.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  articles: Article[] = [];
  isLoading: boolean = true;

  constructor(private articlesService: ArticlesService) {
    this.articlesService.getArticles().subscribe(async (res) => {
      await this.delay(1000);
      this.isLoading = false;
      this.articles = res;
    })
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms) );
  }
}
