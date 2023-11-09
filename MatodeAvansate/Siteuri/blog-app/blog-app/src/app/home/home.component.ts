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
    this.articlesService.getArticles().subscribe(async (res) => {
      await service.delay(1000);
      this.isLoading = false;
      this.articles = res;
    })
  }
}
