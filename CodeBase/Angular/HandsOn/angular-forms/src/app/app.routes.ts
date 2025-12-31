import { Routes } from '@angular/router';
import { TemplateDemo1 } from './Template/template-demo1/template-demo1';
import { TemplateDemo2 } from './Template/template-demo2/template-demo2';
import { TemplateDemo3 } from './Template/template-demo3/template-demo3';
import { ReactiveDemo1 } from './Reactive/reactive-demo1/reactive-demo1';
import { ReactiveDemo2 } from './Reactive/reactive-demo2/reactive-demo2';
import { ReactiveDemo3 } from './Reactive/reactive-demo3/reactive-demo3';
export const routes: Routes = [
    { path: 'template-demo1', component: TemplateDemo1 },
    { path: 'template-demo2', component: TemplateDemo2 },
    { path: 'template-demo3', component: TemplateDemo3 },
    { path: 'reactive-demo1', component: ReactiveDemo1 },
    { path: 'reactive-demo2', component: ReactiveDemo2 },
    { path: 'reactive-demo3', component: ReactiveDemo3 },
];
