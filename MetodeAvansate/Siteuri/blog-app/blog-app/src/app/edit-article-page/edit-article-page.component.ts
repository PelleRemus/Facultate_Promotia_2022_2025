import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ArticlesService } from '../services/articles.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from '../models/article';

@Component({
  selector: 'app-edit-article-page',
  templateUrl: './edit-article-page.component.html',
  styleUrls: ['./edit-article-page.component.scss']
})
export class EditArticlePageComponent {

  article: Article = {} as Article;
  form: FormGroup = new FormGroup({
    title: new FormControl<string>('', [Validators.required]),
    content: new FormControl<string>('', [Validators.required, Validators.minLength(25)]),
  });

  constructor(private articlesService: ArticlesService,
    private route: ActivatedRoute,
    private router: Router) {
      this.article.id = +route.snapshot.params['id'];

      this.articlesService.getOneArticle(this.article.id).subscribe(res => {
        this.article.authorId = res.authorId;
        this.form.controls['title'].setValue(res.title);
        this.form.controls['content'].setValue(res.content);
      })
  }

  editArticle() {
    if(this.form.valid) {

      this.article = {
        id: this.article.id,
        authorId: this.article.authorId,
        title: this.form.controls['title'].value,
        content: this.form.controls['content'].value
      } as Article;

      this.articlesService.editArticle(this.article.id, this.article).subscribe(res => {
        this.router.navigate(['article', this.article.id]);
      })
    }
  }
}
