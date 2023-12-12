import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Article } from '../models/article';
import { ArticlesService } from '../services/articles.service';

@Component({
  selector: 'app-add-article-page',
  templateUrl: './add-article-page.component.html',
  styleUrls: ['./add-article-page.component.scss']
})
export class AddArticlePageComponent {

  form: FormGroup = new FormGroup({
    title: new FormControl<string>('', [Validators.required]),
    content: new FormControl<string>('', [Validators.required, Validators.minLength(25)]),
  });

  constructor(private articlesService: ArticlesService) { }

  addArticle() {
    if(this.form.valid) {
      let article: Article = {
        title: this.form.controls['title'].value,
        content: this.form.controls['content'].value
      } as Article;

      this.articlesService.postArticle(article).subscribe(res => {
        console.log(res);
      })
    }
  }
}
