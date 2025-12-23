import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Demo1 } from "./demo1/demo1";
import { Demo2 } from './demo2/demo2';
import { Demo3 } from './demo3/demo3';
import { Demo4 } from "./demo4/demo4";
import { Demo5 } from "./demo5/demo5";
import { Demo6 } from "./demo6/demo6";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Demo1, Demo2, Demo3, Demo4, Demo5, Demo6],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('angular-one-way-bidning');
}
