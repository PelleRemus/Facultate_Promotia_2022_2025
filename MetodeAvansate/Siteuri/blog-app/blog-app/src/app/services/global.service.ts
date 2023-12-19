import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  baseURL: string = "https://localhost:7107/";
  private search: string = '';
  isDarkMode = false;
  isLoggedIn = false;

  constructor() { }

  searchChange: Subject<string> = new Subject<string>();

  setSearch(search: string) {
    this.search = search;
    this.searchChange.next(search);
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms) );
  }

  setLogIn(isLoggedIn: boolean) {
    this.isLoggedIn = isLoggedIn;
  }
}
