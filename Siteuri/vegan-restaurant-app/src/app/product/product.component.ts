import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../product';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent {

  product?: Product;

  // folosind proprietatea snapshot din ActivatedRoute, putem afla valoarea parametrilor din URL.
  // proprietatea care ne intereseaza in cazul de fata este id-ul, pentru a sti care este produsul ce trebuie afisat pe pagina
  constructor(private productsService: ProductsService, private route: ActivatedRoute) {
    let id = route.snapshot.params['id'];
    productsService.getProduct(id).subscribe(res => {
      this.product = res;
    })
  }
}
