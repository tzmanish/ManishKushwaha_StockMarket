import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FlashMessagesModule } from 'angular2-flash-messages';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Views/login/login.component';
import { SignupComponent } from './Views/signup/signup.component';
import { AccountService } from './Services/account.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NotFoundComponent } from './Views/not-found/not-found.component';
import { NavbarComponent } from './Views/navbar/navbar.component';
import { HomeComponent } from './Views/home/home.component';
import { EditProfileComponent } from './Views/edit-profile/edit-profile.component';
import { IPOComponent } from './Views/User/ipo/ipo.component';
import { CompareCompanyComponent } from './Views/User/compare-company/compare-company.component';
import { ImportExcelComponent } from './Views/Admin/import-excel/import-excel.component';
import { ManageCompanyComponent } from './Views/Admin/manage-company/manage-company.component';
import { UpdateIPOComponent } from './Views/Admin/update-ipo/update-ipo.component';
import { ManageAccountComponent } from './Views/Admin/manage-account/manage-account.component';
import { BackButtonComponent } from './Views/back-button/back-button.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    NotFoundComponent,
    NavbarComponent,
    HomeComponent,
    EditProfileComponent,
    IPOComponent,
    CompareCompanyComponent,
    ImportExcelComponent,
    ManageCompanyComponent,
    UpdateIPOComponent,
    ManageAccountComponent,
    BackButtonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FlashMessagesModule.forRoot(),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
