import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Views/login/login.component';
import { SignupComponent } from './Views/signup/signup.component';
import { NotFoundComponent } from './Views/not-found/not-found.component';
import { NavbarComponent } from './Views/navbar/navbar.component';


const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'register', component:SignupComponent},
  {path:'**', component:NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
