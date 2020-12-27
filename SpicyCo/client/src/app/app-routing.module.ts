import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products/products.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot([
    {path: 'products', component: ProductsComponent},
    {path: '', component: ProductsComponent, pathMatch: 'full'},
    {path: '**', redirectTo: '/products'},
    {path: 'login', component: LoginComponent},
  ])],
  exports: [RouterModule]
})
export class AppRoutingModule { }
