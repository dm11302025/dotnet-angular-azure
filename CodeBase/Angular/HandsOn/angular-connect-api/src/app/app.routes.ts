import { Routes } from '@angular/router';
import { ViewFlights } from './view-flights/view-flights';
import { EditFlight } from './edit-flight/edit-flight';
import { AddFlight } from './add-flight/add-flight';

export const routes: Routes = [
    { path: 'view-all', component: ViewFlights },
    { path: 'edit', component: EditFlight },
    { path: 'add', component: AddFlight },
    { path: '', component: ViewFlights }
];
