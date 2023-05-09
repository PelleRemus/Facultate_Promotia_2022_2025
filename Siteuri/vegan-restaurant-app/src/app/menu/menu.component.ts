import { Component } from '@angular/core';
import { Product } from '../product';
import { ProductsService } from '../services/products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {

  products: Product[] = [];
  
  // parametrii din constructor, in Angular, primesc valoare o singura data la inceputul executarii aplicatiei
  // si sunt "injectati" direct in constructor, prin Dependency Injection (DI): https://angular.io/guide/dependency-injection
  constructor(private productsService: ProductsService, private router: Router) {
    // folosind subscribe, "asteptam" sa primim datele din Observable, acestea fiind returnate in res.
    productsService.getProductList().subscribe(res => {
      this.products = res;
    });
  }

  // obiectul router se ocupa de navigarea in pagina. Poate primi o lista de parametri,
  // acestea reprezentand intreaga cale ce va forma url-ul final. Ruta rezultata din codul de mai jos
  // pentru id-ul 5 va fi "/product/5".
  navigateToProduct(id: number) {
    this.router.navigate(['product', id]);
  }
}
