import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { ProductComponent } from './product/product.component';

// acestea sunt toate rutele aplicatiei.
// "path" reprezinta calea din url pe care trebuie urmata pentru a ajunge la pagina respectiva
// "component" reprezinta componenta care va fi folosita pe post de pagina
// pentru a avea url-ul de baza accesibil, vom adauga si un path cu un string gol,
// care ne va redirectiona pe pagina de home.
// exista si parametri intr-un url, pe care ii reprezentam cu simbolul ':' in fata numelui parametrului
const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'menu', component: MenuComponent },
  { path: 'product/:id', component: ProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
