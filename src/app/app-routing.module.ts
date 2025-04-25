import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { ProductComponent } from './product/product.component';
import { ShopsComponent } from './shops/shops.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [

  {path : 'home', component:HomeComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component:LoginComponent},
  { path: 'Signup', component:RegistrationComponent},
  { path: 'Products', component:ProductComponent},
  { path: 'shops', component:ShopsComponent},
  { path: 'contactus', component:ContactUsComponent},
  { path: 'aboutus', component:AboutUsComponent},
  { path: 'cart', component:CartComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
