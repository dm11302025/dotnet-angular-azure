import { Component } from '@angular/core';

@Component({
  selector: 'app-demo3',
  imports: [],
  templateUrl: './demo3.html',
  styleUrl: './demo3.css',
})
export class Demo3 {
  url: string = 'http://www.twitter.com';
  width: number = 100
  height: number = 100
  changUrl() {
    this.url = 'http://www.msn.com';
    this.height = 200;
    this.width = 200;
  }
}
