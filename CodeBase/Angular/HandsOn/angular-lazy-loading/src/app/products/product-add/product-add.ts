import { Component } from '@angular/core';
import { ProductService } from '../product-service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-product-add',
  imports: [FormsModule],
  templateUrl: './product-add.html',
  styleUrl: './product-add.css',
})
export class ProductAdd {
  name = '';
  price = 0;

  constructor(
    private service: ProductService,
    private router: Router
  ) { }

  save() {
    this.service.add({
      id: Date.now(),
      name: this.name,
      price: this.price
    });
    this.router.navigate(['/products']);
  }
}
