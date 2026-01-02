import { Routes } from '@angular/router';
import { Sender } from './sender/sender';
import { Receiver } from './receiver/receiver';

export const routes: Routes = [
    { path: 'sender', component: Sender },
    { path: 'receiver', component: Receiver }
];
