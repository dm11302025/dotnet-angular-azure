import { Routes } from '@angular/router';
import { Home } from './home/home';
import { About } from './about/about';
import { Contact } from './contact/contact';
import { Products } from './products/products';
import { PageNotFound } from './page-not-found/page-not-found';
import { Login } from './login/login';
import { AdminDashboard } from './Admin/admin-dashboard/admin-dashboard';
import { CustomerDashboard } from './Customer/customer-dashboard/customer-dashboard';
import { Users } from './Admin/users/users';
import { Orders } from './Admin/orders/orders';
import { ShowProducts } from './Admin/show-products/show-products';
import { EditProfile } from './Customer/edit-profile/edit-profile';
import { SearchProduct } from './Customer/search-product/search-product';
import { UserOrders } from './Customer/user-orders/user-orders';

export const routes: Routes = [
    { path: 'home', component: Home },
    { path: 'about', component: About },
    { path: 'contact', component: Contact },
    { path: 'products', component: Products },
    { path: 'login', component: Login },
    // route for admin dashboard with children routes
    {
        path: 'admin-dashboard/:uname', component: AdminDashboard, children: [
            { path: 'users', component: Users },
            { path: 'view-products', component: ShowProducts },
            { path: 'orders', component: Orders }
        ]
    },
    // route for customer dashboard with children routes
    {
        path: 'customer-dashboard/:uname', component: CustomerDashboard, children: [
            { path: 'edit-profile', component: EditProfile },
            { path: 'search', component: SearchProduct },
            { path: 'user-orders', component: UserOrders }
        ]
    },
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: '**', component: PageNotFound }
];
