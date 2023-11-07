import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from  '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, NgModel } from '@angular/forms';
import { NgxBootstrapIconsModule, envelopeFill, phoneFill, giftFill } from 'ngx-bootstrap-icons';
const icons = {
  envelopeFill,
  phoneFill,
  giftFill
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

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FollowersPageComponent,
    AboutUsComponent,
    ContactUsComponent,
    ArticlePageComponent,
    UserPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    NgxBootstrapIconsModule.pick(icons)
  ],
  providers: [
    NgModel
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
