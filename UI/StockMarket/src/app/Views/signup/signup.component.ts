import { Component, OnInit, ViewChild } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/user';
import { NgForm, ValidationErrors } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent implements OnInit {
  user:User;
  istaken:boolean = false;
  @ViewChild('signupForm') form:NgForm;
  errMsg:string;

  constructor(private service:AccountService) { }

  ngOnInit(): void {
    this.user = {
      username:'',
      password:'',
      email:'',
      mobile:''
    }
    this.errMsg = "";
  }

  onSubmit(){
    if(this.isTaken(), this.istaken){
      this.errMsg = "Username already taken";
    } 

    this.service.register(this.form.value).subscribe(response => {
      console.log("success");
      //navigate to home
    }, err => {
      if(err.status == 0) this.errMsg = "Connection lost with server, please try again later."
      else this.errMsg = "Unknown error."
    });
  }

  public isTaken():void{
    if(this.user.username.length<3) this.istaken = false;
    else this.service.isTaken(this.user.username)
      .subscribe(taken=>{
        this.istaken =  (taken === true);
      }, err=>{
        this.istaken = false;   //Can't check.
      });
  }

}
