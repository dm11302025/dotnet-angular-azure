import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-demo4',
  imports: [CommonModule],
  templateUrl: './demo4.html',
  styleUrl: './demo4.css'
})
export class Demo4 {
  tasks = [
    { title: "Pay Bills", done: true },
    { title: "Go Shopping", done: false },
    { title: "Finish Angular Project", done: true }
  ];

}
