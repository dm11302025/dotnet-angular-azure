import { Component } from '@angular/core';

@Component({
  selector: 'app-demo2',
  imports: [],
  templateUrl: './demo2.html',
  styleUrl: './demo2.css',
})
export class Demo2 {
count:number=0;
Increment()
{
  this.count++;
}
Decrement()
{
  this.count--;
}
}
