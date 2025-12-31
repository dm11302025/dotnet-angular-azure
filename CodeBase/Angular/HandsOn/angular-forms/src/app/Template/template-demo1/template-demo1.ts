import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-template-demo1',
  imports: [FormsModule, CommonModule],
  templateUrl: './template-demo1.html',
  styleUrl: './template-demo1.css'
})
export class TemplateDemo1 {
  submitted = false;
  onSubmit(form: NgForm) {
    this.submitted = true;
    console.log(form.value); // { name: "John", email: "john@example.com" }
    console.log(form.value.name); // John
    console.log(form.value.email); // john@example.com

  }

}
