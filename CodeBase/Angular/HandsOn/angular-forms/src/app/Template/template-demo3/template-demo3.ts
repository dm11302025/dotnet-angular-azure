import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-template-demo3',
  imports: [CommonModule, FormsModule],
  templateUrl: './template-demo3.html',
  styleUrl: './template-demo3.css'
})
export class TemplateDemo3 {
  submitted = false;
  onSubmit(form: any) {
    this.submitted = true;
    console.log(form.value);
    alert("Registration Successful!");
  }
}
