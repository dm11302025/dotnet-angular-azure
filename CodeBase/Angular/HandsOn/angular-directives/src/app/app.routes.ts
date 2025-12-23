import { Routes } from '@angular/router';
import { Demo1 } from './demo1/demo1';
import { Demo2 } from './demo2/demo2';
import { Demo3 } from './demo3/demo3';
import { Demo4 } from './demo4/demo4';
import { Demo5 } from './demo5/demo5';
import { Project } from './project/project';

export const routes: Routes = [
    { path: 'demo1', component: Demo1 },
    { path: 'demo2', component: Demo2 },
    { path: 'demo3', component: Demo3 },
    { path: 'demo4', component: Demo4 },
    { path: 'demo5', component: Demo5 },
    { path: 'project', component: Project }
];
