import { Component, OnInit, ViewChild } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/user';
import { NgForm} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  user:User;
  @ViewChild('loginForm') form:NgForm;
  errMsg:string;

  constructor(private service:AccountService) { }

  ngOnInit(): void {
    this.user = {
      Username:'',
      Password:''
    }
  }

  onSubmit(){
    this.service
      .authenticate(this.user)
      .subscribe(U=>{
        console.log(U);
        this.resetForm();
        // Set session
        // redirect to homepage
      },err=>{
        this.resetForm();
        this.errMsg = 
        (err.error.text) ? 
          err.error.text : 
          err.error.error.message ? 
              `${err.status} - ${err.error.error.message}` : 
              err.status?
              `${err.status} - ${err.statusText}` : 
              'Server error';
      });
  }

  public resetForm(){
    this.errMsg = "";
    // this.loginForm.reset();
  }
}
