import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Demo } from "./demo/demo";
import { Demo2 } from "./demo2/demo2";
import { Demo3 } from "./demo3/demo3";
import { Demo4 } from "./demo4/demo4";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Demo, Demo2, Demo3, Demo4],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
 title:string="Welcome to Angular App Dev!!!";
 age:number=21;
 isActive:boolean=true;
}
