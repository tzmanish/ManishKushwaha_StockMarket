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
    private service:AccountService,
    private flashMessages: FlashMessagesService
  ) { }

  ngOnInit(): void {
    this.service.isLoggedIn().subscribe(
      () => this.user = JSON.parse(localStorage.getItem("session")).user, 
      () => this.router.navigateByUrl("login")
    );
  }

  logout(){
    localStorage.clear();
    this.flashMessages.show('You are now logged out.', { cssClass: 'alert-info'});
    this.router.navigateByUrl("login");
  }

}
