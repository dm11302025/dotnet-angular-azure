import { Component } from '@angular/core';

@Component({
  selector: 'app-demo6',
  imports: [],
  templateUrl: './demo6.html',
  styleUrl: './demo6.css'
})
export class Demo6 {
  name: string = 'Virat';
  save() {
    this.name = 'Rohith';
  }
}
