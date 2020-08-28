import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  role:string;
  username:string;

  constructor(private router:Router) { }

  ngOnInit(): void {
    const user = JSON.parse(localStorage.getItem("session"))?.user;
    if(!user){
      this.router.navigateByUrl("login");
      return;
    }
    this.role = user.role;
    this.username = user.username;
  }

  logout(){
    localStorage.clear();
    this.router.navigateByUrl("login");
  }

}
