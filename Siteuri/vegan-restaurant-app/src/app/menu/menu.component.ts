import { Component } from '@angular/core';
import { Product } from '../product';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {
  product: Product = {
    imageUrl: "https://restaumatic-production.imgix.net/uploads/accounts/34267/media_library/1e6cb911-1aa4-4a01-b9d0-07c3a8478c4c.jpg?auto=compress&blur=0&crop=focalpoint&fit=max&fp-x=0.5&fp-y=0.5&h=auto&rect=0%2C0%2C1024%2C683&w=600",
    name: "Salată Vital",
    description: "150 g (ţelină, sfeclă roşie, hrean, ulei presat la rece, sare, lămâie)",
    price: 10
  } as Product;
}
