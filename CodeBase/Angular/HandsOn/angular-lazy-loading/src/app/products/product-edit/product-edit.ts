import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../product-service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-product-edit',
  imports: [FormsModule],
  templateUrl: './product-edit.html',
  styleUrl: './product-edit.css',
})
export class ProductEdit {
  product: any;

  constructor(
    private route: ActivatedRoute,
    private service: ProductService,
    private router: Router
  ) {
    // Get product ID from route parameters
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.product = this.service.getById(id);
  }

  update() {
    this.service.update(this.product);
    this.router.navigate(['/products']);
  }
}
