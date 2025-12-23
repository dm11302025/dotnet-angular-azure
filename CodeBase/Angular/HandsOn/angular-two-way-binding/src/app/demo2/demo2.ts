import { Component } from '@angular/core';
import { Book } from '../book';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-demo2',
  imports: [FormsModule, CommonModule],
  templateUrl: './demo2.html',
  styleUrl: './demo2.css'
})
export class Demo2 {
  book: Book;
  books: Book[] = []; //book array
  language: string[] = ["English", "Hindi", "Telugu", "Tamil"];
  constructor() {
    //initiate book object
    this.book = {
      ISBN: 0, Title: '', Price: 0, Author: '',
      PubDate: new Date(), Lang: ''
    }
  }
  save() {
    this.book.ISBN = Math.floor(Math.random() * 409328439)
    //add book details to the array
    this.books.push(this.book);
    console.log(this.book);
    console.log(this.books)
    //cleare the form data
    this.book = {
      ISBN: 0, Title: '', Price: 0, Author: '',
      PubDate: new Date(), Lang: ''
    }
  }
}
