import { Component } from '@angular/core';

@Component({
  selector: 'app-demo5',
  imports: [],
  templateUrl: './demo5.html',
  styleUrl: './demo5.css'
})
export class Demo5 {
  img_source: string = "car1.jpg";
  width: number = 200
  height: number = 300;
  url_path = 'http://google.co.in';
  Upload(): void {
    this.img_source = "car2.jpeg";
    this.height = 400;
    this.width = 300;
    this.url_path = 'http://twitter.com';

  }
}
