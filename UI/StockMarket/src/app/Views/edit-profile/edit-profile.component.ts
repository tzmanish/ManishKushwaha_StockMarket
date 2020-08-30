import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from 'src/app/Models/user';
import { AccountService } from 'src/app/Services/account.service';
import { NgForm } from '@angular/forms';
import { FlashMessagesService } from 'angular2-flash-messages';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {
  user:User;
  loading:boolean = false;
  curPass: string;
  newPass: string;

  @ViewChild('profileForm') form:NgForm;

  constructor(private service: AccountService, private flashMessage: FlashMessagesService) { }

  ngOnInit(): void {
    this.user = this.service.getUserData();
  }

  public updateProfile(){
    this.loading=true;

    this.service.authenticate({username: this.user.username, password: this.curPass})
      .subscribe(()=>{
        this.user.password = this.newPass? this.newPass: this.curPass;

        this.service.updateUserData(this.user).subscribe(U => {
            this.user = U;
            let local = JSON.parse(localStorage.getItem("session"));
            local.user = U;
            localStorage.setItem("session", JSON.stringify(local));

            this.flashMessage.show("Profile updated", {cssClass: 'alert-success', timeout: 4000});
            this.curPass = "";
            this.newPass = "";
          }, ()=>{this.user = this.service.getUserData()});

      }, ()=>{this.user = this.service.getUserData()});

    this.loading = false;
  }
}
