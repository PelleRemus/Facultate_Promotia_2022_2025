import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LayoutPageComponent } from './core/layout/pages/layout-page/layout-page.component';
import { NotFoundPageComponent } from './core/layout/pages/not-found-page/not-found-page.component';

const routes: Routes = [
  {
    path: "",
    component: LayoutPageComponent,
    children: [
      {
        path: "",
        redirectTo: "home",
        pathMatch: "full"
      },
      {
        path: "home",
        loadChildren: () =>
          import("./features/home/home.module").then(m => m.HomeModule)
      },
      {
        path: "authentication",
        loadChildren: () =>
          import("./features/login/login.module").then(m => m.LoginModule)
      },
      {
        path: "**",
        component: NotFoundPageComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
