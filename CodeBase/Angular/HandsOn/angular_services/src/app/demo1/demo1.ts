import { Component } from '@angular/core';
import { Greet } from '../greet';
@Component({
  selector: 'app-demo1',
  imports: [],
  templateUrl: './demo1.html',
  styleUrl: './demo1.css',
})
export class Demo1 {
  constructor(private obj:Greet)
  {
    console.log(obj.greet())
  }
}
