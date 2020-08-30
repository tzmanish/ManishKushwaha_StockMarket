import { Component, OnInit, ViewChild } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/user';
import { NgForm} from '@angular/forms';
import { FlashMessagesService } from 'angular2-flash-messages';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  user:User = <User>{ };
  istaken:boolean = false;
  locked:boolean = true;
  @ViewChild('signupForm') form:NgForm;
  loading:boolean = false;

  constructor(
    private service:AccountService, 
    private router: Router,
    private flashMessage: FlashMessagesService
  ) { }

  ngOnInit(): void { }

  showAlert(alertClass:string, message: string|any):void{
    let errMsg = typeof message === "string"? message :
      (message.error?.text) ? message.error.text : 
            message.error.error?.message ? `${message.status} - ${message.error.error.message}` : 
              message.status? `${message.status} - ${message.statusText}` : 
              'Server error';
    this.flashMessage.show(errMsg, {cssClass: `alert-${alertClass}`, timeout: 4000});
  }

  onSubmit(){
    if(this.isTaken(), this.istaken){
      this.showAlert("danger", "Username already taken");
    }
    this.service
      .register(this.form.value)
      .subscribe(() => {
        this.flashMessage.show(
          "Registration successful. A confirmation email have been sent to "+this.user.email,
          {cssClass: 'alert-success', timeout: 4000}
        );
        this.router.navigateByUrl("login");
      }, err => this.showAlert("danger", err));
  }

  public isTaken():void{
    if(this.user.username.length<3) this.istaken = false;
    else this.service.isTaken(this.user.username)
      .subscribe(taken=>this.istaken =  (taken === true), err=>{
        this.istaken = false;   //Can't check.
        this.showAlert("danger", err);
      });
  }
}
