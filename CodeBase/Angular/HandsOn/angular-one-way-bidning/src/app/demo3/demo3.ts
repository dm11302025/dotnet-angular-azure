import { Component } from '@angular/core';
import { Product } from '../product';
@Component({
  selector: 'app-demo3',
  imports: [],
  templateUrl: './demo3.html',
  styleUrl: './demo3.css'
})
export class Demo3 {
  product: Product;
  products: Product[] = []
  constructor() {
    this.product = {
      Id: 304, Name: "Bottle",
      Price: 100, Stock: 20
    };
    this.products = [
      { Id: 304, Name: "Bottle", Price: 100, Stock: 20 },
      { Id: 305, Name: "Pen", Price: 10, Stock: 20 },
      { Id: 306, Name: "Pencil", Price: 10, Stock: 20 },
      { Id: 307, Name: "Book", Price: 50, Stock: 20 },
      { Id: 308, Name: "Mouse", Price: 500, Stock: 20 },
    ];
  }
}
