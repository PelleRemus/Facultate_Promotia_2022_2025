import { Component } from '@angular/core';
import { Article } from '../models/article';
import { ArticlesService } from '../services/articles.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html',
  styleUrls: ['./article-page.component.scss']
})
export class ArticlePageComponent {
  article: Article = {} as Article;
  isLoading: boolean = true;

  constructor(private articlesService: ArticlesService, private route: ActivatedRoute) {
    let id: number = +route.snapshot.params['id'];

    this.articlesService.getOneArticle(id).subscribe(async (res) => {
      await this.delay(1000);
      this.isLoading = false;
      this.article = res;
    });
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms) );
  }
}
