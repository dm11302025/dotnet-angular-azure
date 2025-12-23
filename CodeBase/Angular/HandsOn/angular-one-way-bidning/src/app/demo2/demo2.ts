import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-demo2',
  imports: [CommonModule],
  templateUrl: './demo2.html',
  styleUrl: './demo2.css'
})
export class Demo2 {
  //array
  colors: string[] = ["Red", "Green", "Blue", "Yellow"];
  cities: string[] = ["Pune", "Mumbai", "Chennai", "Kolkata"];
  numbers: number[] = [10, 20, 30, 40, 50]
}
