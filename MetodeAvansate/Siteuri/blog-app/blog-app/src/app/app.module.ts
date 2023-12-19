import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from  '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, NgModel, ReactiveFormsModule } from '@angular/forms';
import { NgxBootstrapIconsModule, envelopeFill, phoneFill, giftFill, pencilFill, trashFill } from 'ngx-bootstrap-icons';
const icons = {
  envelopeFill,
  phoneFill,
  giftFill,
  pencilFill,
  trashFill
};

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FollowersPageComponent } from './followers-page/followers-page.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { ArticlePageComponent } from './article-page/article-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { AddArticlePageComponent } from './add-article-page/add-article-page.component';
import { HttpInterceptorService } from './services/http-interceptor.service';
import { EditArticlePageComponent } from './edit-article-page/edit-article-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FollowersPageComponent,
    AboutUsComponent,
    ContactUsComponent,
    ArticlePageComponent,
    UserPageComponent,
    LoginPageComponent,
    RegisterPageComponent,
    AddArticlePageComponent,
    EditArticlePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    HttpClientModule,
    NgxBootstrapIconsModule.pick(icons)
  ],
  providers: [
    NgModel,
    { provide: HTTP_INTERCEPTORS, useClass: HttpInterceptorService, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
