import { Injectable } from '@angular/core';
import { Product } from './product';
@Injectable({
  providedIn: 'root',
})

export class ProductService {
  private products: Product[] = [
    { id: 1, name: 'Laptop', price: 50000 },
    { id: 2, name: 'Mobile', price: 20000 }
  ];

  getAll() {
    return this.products;
  }

  getById(id: number) {
    return this.products.find(p => p.id === id);
  }

  add(product: Product) {
    this.products.push(product);
  }

  update(product: Product) {
    const index = this.products.findIndex(p => p.id === product.id);
    this.products[index] = product;
  }

  delete(id: number) {
    this.products = this.products.filter(p => p.id !== id);
  }
}