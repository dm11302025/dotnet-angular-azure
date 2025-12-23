import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-demo1',
  imports: [CommonModule],
  templateUrl: './demo1.html',
  styleUrl: './demo1.css'
})
export class Demo1 {
  //variables
  name: string = "Rajan";
  age: number = 25;
  address: string = "Pune";
  isEmployee: boolean = true;
  salary: number = 25000
}
