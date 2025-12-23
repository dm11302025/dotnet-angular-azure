import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-products',
  imports: [CommonModule],
  templateUrl: './products.html',
  styleUrl: './products.css'
})
export class Products {
  products = [
    {
      name: 'Wireless Headphones',
      description: 'High-quality wireless headphones with noise cancellation.',
      price: 2999,
      image: 'https://cdn-icons-png.flaticon.com/512/1042/1042330.png'
    },
    {
      name: 'Smart Watch',
      description: 'Track your fitness and notifications with this smart watch.',
      price: 4999,
      image: 'https://cdn-icons-png.flaticon.com/512/2920/2920256.png'
    },
    {
      name: 'Bluetooth Speaker',
      description: 'Portable Bluetooth speaker with deep bass and long battery life.',
      price: 1999,
      image: 'https://cdn-icons-png.flaticon.com/512/727/727245.png'
    }
  ];

}
