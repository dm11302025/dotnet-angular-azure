import { Routes } from '@angular/router';
import { ProductAll } from './product-all/product-all';
import { ProductEdit } from './product-edit/product-edit';
import { ProductAdd } from './product-add/product-add';
export const PRODUCT_ROUTES: Routes = [
    {
        path: '',
        component: ProductAll,
        children: [
            { path: 'add', component: ProductAdd },
            { path: 'edit/:id', component: ProductEdit }
        ]
    }
];