import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-show-products',
  imports: [CommonModule],
  templateUrl: './show-products.html',
  styleUrl: './show-products.css'
})
export class ShowProducts {
  products = [
    {
      name: 'Laptop',
      description: 'High performance laptop for work and play.',
      price: 55000,
      image: 'https://cdn-icons-png.flaticon.com/512/1792/1792864.png'
    },
    {
      name: 'Smartphone',
      description: 'Latest model smartphone with advanced features.',
      price: 25000,
      image: 'https://cdn-icons-png.flaticon.com/512/2920/2920269.png'
    },
    {
      name: 'Wireless Mouse',
      description: 'Ergonomic wireless mouse for comfortable use.',
      price: 799,
      image: 'https://cdn-icons-png.flaticon.com/512/1055/1055687.png'
    }
  ];
}
