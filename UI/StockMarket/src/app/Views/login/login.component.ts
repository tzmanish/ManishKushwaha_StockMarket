import { Component, OnInit, ViewChild } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/user';
import { NgForm} from '@angular/forms';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  user:User;
  @ViewChild('loginForm') form:NgForm;
  errMsg:string;

  constructor(private service:AccountService, private router: Router) { }

  ngOnInit(): void {
    this.user = {
      Username:'',
      Password:''
    }
  }

  onSubmit(){
    this.lockForm();
    this.service
      .authenticate(this.user)
      .subscribe(Response=>{
        localStorage.setItem("session", JSON.stringify(Response));
        this.router.navigateByUrl("");
      },err=>{
        this.resetForm();
        this.errMsg = 
        (err.error.text) ? 
          err.error.text : 
          (err.error.error.message) ? 
              `${err.status} - ${err.error.error.message}` : 
              (err.status)?
              `${err.status} - ${err.statusText}` : 
              'Server error';
      });
  }

  public lockForm(){
    this.errMsg = "";
    // this.loginForm.reset();
  }

  public resetForm(){
    this.errMsg = "";
    // this.loginForm.reset();
  }
}
