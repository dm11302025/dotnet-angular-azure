import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-demo1',
  imports: [FormsModule],
  templateUrl: './demo1.html',
  styleUrl: './demo1.css'
})
export class Demo1 {
  name: string = 'Virat'
  save() {
    this.name = 'Sachin';
  }
}
