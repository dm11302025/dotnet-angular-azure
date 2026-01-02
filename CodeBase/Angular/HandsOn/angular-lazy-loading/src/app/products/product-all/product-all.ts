import { Component } from '@angular/core';
import { ProductService } from '../product-service';
import { Product } from '../product';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-product-all',
  imports: [RouterModule, CommonModule],
  templateUrl: './product-all.html',
  styleUrl: './product-all.css',
})
export class ProductAll {
  products: Product[] = [];
  constructor(private productService: ProductService) {
    this.products = this.productService.getAll();
  }
  delete(id: number) {
    this.productService.delete(id);
    this.products = this.productService.getAll();
  }
}
