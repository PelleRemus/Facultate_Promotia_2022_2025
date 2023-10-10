import { Injectable } from '@angular/core';
import { Product } from '../product';
import { Observable, of } from 'rxjs';

// elementele injectable pot fi folosite in constructorul altor elemente /componente
@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  // in mod normal, produsele ar fi luate de pe un server (partea de BackEnd a aplicatiei),
  // dar noi deocamdata nu avem un BackEnd (BE), deci vom folosi niste date de test
  private products: Product[] = [
    {
      id: 1,
      imageUrl: "https://restaumatic-production.imgix.net/uploads/accounts/34267/media_library/1e6cb911-1aa4-4a01-b9d0-07c3a8478c4c.jpg?auto=compress&blur=0&crop=focalpoint&fit=max&fp-x=0.5&fp-y=0.5&h=auto&rect=0%2C0%2C1024%2C683&w=600",
      name: "Salată Vital",
      description: "150 g (ţelină, sfeclă roşie, hrean, ulei presat la rece, sare, lămâie)",
      price: 10
    } as Product,
    {
      id: 2,
      imageUrl: "https://restaumatic-production.imgix.net/uploads/accounts/34267/media_library/f01a9649-1a8b-4885-a731-e64ffbf92a14.jpg?auto=compress&blur=0&crop=focalpoint&fit=max&fp-x=0.5&fp-y=0.5&h=auto&rect=0%2C0%2C1024%2C682&w=600",
      name: "Fasole verde scăzută",
      description: "200 g (fasole verde, morcovi, ardei, smântână de soia, pătrunjel, usturoi, ulei, sare)",
      price: 10
    } as Product,
    {
      id: 3,
      imageUrl: "https://restaumatic-production.imgix.net/uploads/accounts/34267/media_library/de3828b3-02a1-4319-8c4f-33e0a529a476.jpg?auto=compress&blur=0&crop=focalpoint&fit=max&fp-x=0.5&fp-y=0.5&h=auto&rect=0%2C0%2C1600%2C1067&w=600",
      name: "Cartofi piure",
      description: "200 g (cartofi, smântână de soia, sare)",
      price: 9
    } as Product
  ];

  constructor() { }

  // pentru a simula conexiunea cu un BE cat mai mult, vom folosi tipul de return primit in urma unui apel spre BE
  // adica Observable. Pe scurt, acesta sugereaza ca nu poate returna imediat datele, pentru ca apelurile dureaza cateva milisecunde,
  // si "observa" cand primim datele. Functia "of" pur si simplu inveleste parametrul intr-un Observable.
  // Puteti cauta explicatii pentru Observable, uitati un exemplu: https://www.youtube.com/watch?v=Rr0tMbmeid8
  getProductList(): Observable<Product[]> {
    return of(this.products);
  }

  getProduct(id: number): Observable<Product> {
    return of(this.products.find(product => product.id == id) || this.products[0]);
  }
}
