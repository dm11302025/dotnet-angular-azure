import { Component } from '@angular/core';
import { Product } from '../product';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-demo4',
  imports: [CommonModule],
  templateUrl: './demo4.html',
  styleUrl: './demo4.css'
})
export class Demo4 {
  count: number = 0;
  product: Product | null = null;
  isShow: boolean = false;
  increment(): void {
    this.count++;
  }
  Save(): void {
    this.isShow = true;
    this.product = {
      Id: 304, Name: "Bottle",
      Price: 100, Stock: 20
    };
  }
}
