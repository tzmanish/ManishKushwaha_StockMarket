import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  username:string;
  role:string;

  constructor() { }

  ngOnInit(): void {
    const user = JSON.parse(localStorage.getItem("session")).user;
    this.username = user.username;
    this.role = user.role;
  }

}
