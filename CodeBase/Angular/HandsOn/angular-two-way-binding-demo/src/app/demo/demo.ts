import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-demo',
  imports: [FormsModule],
  templateUrl: './demo.html',
  styleUrl: './demo.css',
})
export class Demo {
  name: string = 'Virat';
  change() {
    this.name = 'Rohith'
  }
}
