import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  isDarkMode = false;

  constructor() { }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms) );
  }
}
