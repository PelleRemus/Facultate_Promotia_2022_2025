import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { HomeRoutingModule } from './home-routing.module';
import { ContactUsPageComponent } from './pages/contact-us-page/contact-us-page.component';
import { AboutUsPageComponent } from './pages/about-us-page/about-us-page.component';



@NgModule({
  declarations: [
    HomePageComponent,
    ContactUsPageComponent,
    AboutUsPageComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
