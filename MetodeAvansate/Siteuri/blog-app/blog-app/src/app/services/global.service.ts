import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  baseURL: string = "https://localhost:7107/";
  isDarkMode = false;
  isLoggedIn = false;

  constructor() { }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms) );
  }

  setLogIn(isLoggedIn: boolean) {
    this.isLoggedIn = isLoggedIn;
  }
}
