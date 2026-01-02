import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataSharingService {
  // Private BehaviorSubject to hold the current message
  // Initialized with a default message
  // Components can subscribe to message$ to get updates
  private messageSource = new BehaviorSubject<string>('Initial Message');
  // Observable for components to subscribe to
  // Expose the observable part of the BehaviorSubject
  message$ = this.messageSource.asObservable(); 

  updateMessage(newMessage: string): void {
    this.messageSource.next(newMessage); // Update the message
  }
}
