import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Greet {
  greet():string
  {
    return 'Hello World from Service!!!';
  }
}
