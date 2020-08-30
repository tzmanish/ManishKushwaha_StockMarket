import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { FlashMessagesService } from 'angular2-flash-messages';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  user:User;

  constructor( 
    private router:Router,
    private flashMessages: FlashMessagesService,
    public service: AccountService
  ) { }

  ngOnInit(): void {
  }

  logout(){
    this.service.logout();
    this.flashMessages.show('You are now logged out.', { cssClass: 'alert-info'});
    this.router.navigateByUrl("login");
  }

  getUserData():boolean {
    this.user = this.service.getUserData();
    return true;
  }

}
