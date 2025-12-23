import { Component } from '@angular/core';
import { Product } from '../product';
@Component({
  selector: 'app-demo',
  imports: [],
  templateUrl: './demo.html',
  styleUrl: './demo.css',
})
export class Demo {
  //initialize the model
  product: Product = { Id: 0, Name: '', Price: 0 }
  constructor() {
    //assign model data
    this.product = { Id: 34093, Name: 'Laptop', 
      Price: 33330 }
  }
}
