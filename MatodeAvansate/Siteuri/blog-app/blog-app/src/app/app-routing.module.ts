import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FollowersPageComponent } from './followers-page/followers-page.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { ArticlePageComponent } from './article-page/article-page.component';
import { UserPageComponent } from './user-page/user-page.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'followers', component: FollowersPageComponent },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'contact-us', component: ContactUsComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },

  { path: 'article/:id', component: ArticlePageComponent },
  { path: 'user/:id', component: UserPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
