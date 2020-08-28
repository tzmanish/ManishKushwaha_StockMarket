import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Views/login/login.component';
import { SignupComponent } from './Views/signup/signup.component';
import { NotFoundComponent } from './Views/not-found/not-found.component';
import { HomeComponent } from './Views/home/home.component';
import { EditProfileComponent } from './Views/edit-profile/edit-profile.component';
import { CompareCompanyComponent } from './Views/User/compare-company/compare-company.component';
import { IPOComponent } from './Views/User/ipo/ipo.component';
import { ImportExcelComponent } from './Views/Admin/import-excel/import-excel.component';
import { ManageAccountComponent } from './Views/Admin/manage-account/manage-account.component';
import { ManageCompanyComponent } from './Views/Admin/manage-company/manage-company.component';
import { UpdateIPOComponent } from './Views/Admin/update-ipo/update-ipo.component';


const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'register', component:SignupComponent},
  {path:'', component:HomeComponent},
  {path:'profile', component:EditProfileComponent},
  
  //user
  {path:'user/company', component:CompareCompanyComponent},
  {path:'user/ipos', component:IPOComponent},

  //admin
  {path:'admin/excel', component:ImportExcelComponent},
  {path:'admin/accounts', component:ManageAccountComponent},
  {path:'admin/company', component:ManageCompanyComponent},
  {path:'admin/ipos', component:UpdateIPOComponent},

  {path:'**', component:NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
