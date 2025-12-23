import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-orders',
  imports: [CommonModule],
  templateUrl: './orders.html',
  styleUrl: './orders.css'
})
export class Orders {
  orders = [
    {
      orderId: 'ORD1001',
      customer: 'Amit Sharma',
      product: 'Wireless Headphones',
      total: 2999,
      status: 'Delivered'
    },
    {
      orderId: 'ORD1002',
      customer: 'Priya Singh',
      product: 'Smart Watch',
      total: 4999,
      status: 'Pending'
    },
    {
      orderId: 'ORD1003',
      customer: 'Rahul Verma',
      product: 'Bluetooth Speaker',
      total: 1999,
      status: 'Cancelled'
    }
  ];
}
