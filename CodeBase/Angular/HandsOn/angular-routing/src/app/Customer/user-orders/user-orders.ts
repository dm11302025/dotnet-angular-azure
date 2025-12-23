import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-user-orders',
  imports: [CommonModule],
  templateUrl: './user-orders.html',
  styleUrl: './user-orders.css'
})
export class UserOrders {
  orders = [
    {
      orderId: 'ORD2001',
      product: 'Laptop',
      date: '2025-09-10',
      total: 55000,
      status: 'Delivered'
    },
    {
      orderId: 'ORD2002',
      product: 'Wireless Mouse',
      date: '2025-09-12',
      total: 799,
      status: 'Pending'
    }
  ];
}
