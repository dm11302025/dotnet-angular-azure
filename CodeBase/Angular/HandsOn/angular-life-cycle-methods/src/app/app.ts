import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StudentProfileComponent } from './student-profile/student-profile';
@Component({
  selector: 'app-root',
  imports: [RouterOutlet, StudentProfileComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly selectedStudent = 'John Doe';
}
