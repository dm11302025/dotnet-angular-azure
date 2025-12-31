import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive-demo3',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reactive-demo3.html',
  styleUrl: './reactive-demo3.css'
})
export class ReactiveDemo3 {
  // Define the form model(using FormGroup and FormControl)
  submitted = false;
  regForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(6)])
  });
  // Getter methods for easy access to form controls in the template
  get name() { return this.regForm.get('name'); }
  get email() { return this.regForm.get('email'); }
  get password() { return this.regForm.get('password'); }

  onSubmit() {
    this.submitted = true;
    console.log(this.regForm.value);
    alert("Registration Successful!");
  }
}
