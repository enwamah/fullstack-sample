import { Routes } from '@angular/router';
import { ProductsList } from './components/products-list/products-list';
import { ProductForm } from './components/product-form/product-form';



export const routes: Routes = [
  { path: 'products', component: ProductsList },
  { path: 'product-form', component: ProductForm },
];
