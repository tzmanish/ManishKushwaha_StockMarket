import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { User } from 'src/app/Models/user';
import { FormBuilder, FormGroup } from '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user:User;
  loginForm:FormGroup;
  errMsg:string;

  constructor(private service:AccountService, private formBuilder:FormBuilder) {
    this.loginForm = this.formBuilder.group({
      username:"",
      password:""
    });
   }

  ngOnInit(): void {
  }

  onSubmit(){

    this.service.authenticate(this.loginForm.value.username, this.loginForm.value.password)
      .subscribe(U=>{
        this.user = U;
        console.log(`id: ${this.user.id}, username: ${this.user.username}`);
        this.resetForm();
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
    // this.loginForm.reset();
  }
}
