import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-users',
  imports: [CommonModule],
  templateUrl: './users.html',
  styleUrl: './users.css'
})
export class Users {
  users = [
    {
      name: 'Amit Sharma',
      email: 'amit.sharma@example.com',
      role: 'Admin',
      status: 'Active'
    },
    {
      name: 'Priya Singh',
      email: 'priya.singh@example.com',
      role: 'Customer',
      status: 'Active'
    },
    {
      name: 'Rahul Verma',
      email: 'rahul.verma@example.com',
      role: 'Customer',
      status: 'Inactive'
    }
  ];
}
