import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search-product',
  imports: [CommonModule, FormsModule],
  templateUrl: './search-product.html',
  styleUrl: './search-product.css'
})
export class SearchProduct {
  searchText = '';
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

  filteredProducts() {
    if (!this.searchText) return this.products;
    const text = this.searchText.toLowerCase();
    return this.products.filter(
      p =>
        p.name.toLowerCase().includes(text) ||
        p.description.toLowerCase().includes(text)
    );
  }
}
