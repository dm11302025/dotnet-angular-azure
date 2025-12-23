import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Product } from '../product';

@Component({
  selector: 'app-demo4',
  imports: [CommonModule],
  templateUrl: './demo4.html',
  styleUrl: './demo4.css',
})
export class Demo4 {
  //array declaration 
  cities: string[] = ["Hyd", "Pune", "Chennai"];
  //product array
  products: Product[] = []; //empty array
  constructor() {
    this.products = [
      { Id: 1, Name: "Laptop", Price: 34000 },
      { Id: 2, Name: "Mouse", Price: 300 },
      { Id: 3, Name: "Keyboard", Price: 3000 },
      { Id: 4, Name: "Pendrive", Price: 1000 },
      { Id: 5, Name: "Joystics", Price: 4000 },

    ]
  }
}
