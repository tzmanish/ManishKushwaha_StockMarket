import { Component, OnInit, ViewChild } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/user';
import { NgForm} from '@angular/forms';
import { Router } from '@angular/router';
import { FlashMessagesService } from 'angular2-flash-messages';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  user:User = <User>{ };
  @ViewChild('loginForm') form:NgForm;
  loading:boolean = false;

  constructor(
    private service:AccountService, 
    private router: Router, 
    private flashMessage: FlashMessagesService
  ) { }

  ngOnInit(): void {
    if(this.service.isAuthenticated()){
        this.flashMessage.show( "You're already logged in.", {cssClass: 'alert-warning', timeout: 4000} );
        this.router.navigateByUrl("");
      }
  }

  onSubmit(user:User){
    console.log(user);
    this.loading = true;
    this.service
      .authenticate(user)
      .subscribe(Response=>{
        localStorage.setItem("session", JSON.stringify(Response));
        this.router.navigateByUrl("");
      },err=>{
        console.log(err);
        this.resetForm();
      });
    this.loading = false;
  }

  public resetForm(){
    this.user = <User>{};
  }
}
