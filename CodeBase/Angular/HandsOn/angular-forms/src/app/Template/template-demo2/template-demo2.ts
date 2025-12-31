import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-template-demo2',
  imports: [CommonModule, FormsModule],
  templateUrl: './template-demo2.html',
  styleUrl: './template-demo2.css'
})
export class TemplateDemo2 {
  submitted = false;
  onSubmit(form: NgForm) {
    this.submitted = true;
    console.log(form.value)
    // { name: "John", email: "
    alert("Registration Successful!");
  }
}
