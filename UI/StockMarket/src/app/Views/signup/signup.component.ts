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
  @ViewChild('signupForm') form:NgForm;
  loading:boolean = false;

  constructor(
    private service:AccountService, 
    private router: Router,
    private flashMessage: FlashMessagesService
  ) { }

  ngOnInit(): void { }

  onSubmit(){
    this.loading=true;

    if(this.isTaken(), this.istaken){
      this.flashMessage.show("Username already taken", {cssClass: "alert-danger", timeout: 4000});
      this.loading = false;
    }
    else this.service.register(this.form.value)
      .subscribe(() => {
        this.flashMessage.show(
          "Registration successful. A confirmation email have been sent to "+this.user.email,
          {cssClass: 'alert-success', timeout: 4000}
          );
          this.router.navigateByUrl("login");
      }, ()=>{this.loading = false});
  }

  public isTaken():void{
    if(this.user.username.length<3) this.istaken = false;
    else this.service.isTaken(this.user.username)
      .subscribe(taken=>this.istaken =  (taken === true), ()=>{
        this.istaken = false;   //Can't check.
    });
  }
}
