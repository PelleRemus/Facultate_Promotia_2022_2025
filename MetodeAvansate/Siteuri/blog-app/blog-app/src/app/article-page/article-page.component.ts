import { Component } from '@angular/core';
import { Article } from '../models/article';
import { ArticlesService } from '../services/articles.service';
import { ActivatedRoute } from '@angular/router';
import { GlobalService } from '../services/global.service';
import { router } from 'ngx-bootstrap-icons';
import { Location } from '@angular/common';

@Component({
  selector: 'app-article-page',
  templateUrl: './article-page.component.html',
  styleUrls: ['./article-page.component.scss']
})
export class ArticlePageComponent {
  article: Article = {} as Article;
  isLoading: boolean = true;

  constructor(private articlesService: ArticlesService,
    private service: GlobalService,
    private route: ActivatedRoute,
    private location: Location) {
    let id: number = +this.route.snapshot.params['id'];

    this.articlesService.getOneArticle(id).subscribe(async (res) => {
      await this.service.delay(1000);
      this.isLoading = false;
      this.article = res;
    });
  }

  deleteArticle() {
    this.articlesService.deleteArticle(this.article.id).subscribe(res => {
      this.location.back();
    })
  }
}
