import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/user';
import { FormBuilder } from '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user:User;
  loginForm:any;
  errMsg:string;

  constructor(private service:AccountService, private formBuilder:FormBuilder) {
    this.loginForm = this.formBuilder.group({
      username:"",
      password:""
    });
   }

  ngOnInit(): void {
  }

  onSubmit(loginCredentials){
    this.service.authenticate(loginCredentials.username, loginCredentials.password)
      .subscribe(U=>{
        this.user = U;
        this.errMsg = `id: ${this.user.id}, username: ${this.user.username}`;
        // redirect to homepage
      },err=>{
        this.resetForm();
        if(err.status == 200) this.errMsg = "Invaid Credentials";
        else if(err.status == 0) this.errMsg = "Connection lost with server, please try again later."
        else this.errMsg = "Unknown error."
      });
  }

  public resetForm(){
    this.errMsg = "";
  }
}
