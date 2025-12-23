import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-demo5',
  imports: [CommonModule],
  templateUrl: './demo5.html',
  styleUrl: './demo5.css'
})
export class Demo5 {
  stockList = [
    { name: "Apples", quantity: 5 },
    { name: "Oranges", quantity: 20 },
    { name: "Bananas", quantity: 15 }
  ];

}
