// app.routes.ts
import { Routes } from '@angular/router';
import { Home } from './home/home';

export const routes: Routes = [
    {
        path: '', component: Home
    },
    // Lazy load the admin module
    // Updated to load ADMIN_ROUTES
    //
    {
        path: 'admin', loadChildren: () =>
            //lazy load the admin routes
            //lazy loading happens here
            import('./admin/admin.routes').then(m => m.ADMIN_ROUTES)
    },
    {
        path: 'products',
        loadChildren: () =>
            import('./products/product.routes').then(m => m.PRODUCT_ROUTES)
    }
];
