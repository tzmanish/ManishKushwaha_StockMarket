import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

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

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    NotFoundComponent,
    NavbarComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
