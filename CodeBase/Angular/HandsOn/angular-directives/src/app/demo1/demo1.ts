import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-demo1',
  imports: [CommonModule],
  templateUrl: './demo1.html',
  styleUrl: './demo1.css'
})
export class Demo1 {
  products = [
    { name: 'Laptop', price: 50000 },
    { name: 'Mobile', price: 20000 },
    { name: 'Tablet', price: 15000 }
  ];
}
