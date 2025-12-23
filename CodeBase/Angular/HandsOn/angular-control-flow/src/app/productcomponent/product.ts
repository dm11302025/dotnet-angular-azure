import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Product } from '../product';
@Component({
  selector: 'app-product',
  imports: [CommonModule, FormsModule],
  templateUrl: './product.html',
  styleUrl: './product.css',
})
export class ProductComponent {
  // State variables (NO signals)
  products: Product[] = [];
   isEditing = false;
  // Form model
  productForm: Product = {
    id: 0,
    name: '',
    price: 0
  };
  constructor() {
    // Simulate API call
    setTimeout(() => {

      this.products = [
        { id: 1, name: 'Laptop', price: 80000 },
        { id: 2, name: 'Mobile', price: 40000 }
      ];

    }, 1000);
  }
  addProduct() {
    const newProduct: Product = {
      ...this.productForm,
      id: Date.now()
    };
    this.products.push(newProduct);
    this.resetForm();
  }
  editProduct(product: Product) {
    this.productForm = { ...product };
    this.isEditing = true;
  }

  updateProduct() {
    const index = this.products.findIndex(
      p => p.id === this.productForm.id
    );
    if (index !== -1) {
      this.products[index] = { ...this.productForm };
    }
    this.resetForm();
  }

  deleteProduct(id: number) {
    this.products = this.products.filter(p => p.id !== id);
  }

  resetForm() {
    this.productForm = { id: 0, name: '', price: 0 };
    this.isEditing = false;
  }
}
