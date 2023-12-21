import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './layout/components/navbar/navbar.component';
import { FooterComponent } from './layout/components/footer/footer.component';
import { LayoutPageComponent } from './layout/pages/layout-page/layout-page.component';
import { NotFoundPageComponent } from './layout/pages/not-found-page/not-found-page.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    NavbarComponent,
    FooterComponent,
    LayoutPageComponent,
    NotFoundPageComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class CoreModule { }
