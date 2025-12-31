import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-reactive-demo1',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './reactive-demo1.html',
  styleUrl: './reactive-demo1.css'
})
export class ReactiveDemo1 {
  // Define the form model(using FormGroup and FormControl)
  // with validation rules
  userForm = new FormGroup({
    name: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email])
  });
  submitted = false;

  onSubmit() {
    this.submitted = true;
    console.log(this.userForm.value);
  }
}
