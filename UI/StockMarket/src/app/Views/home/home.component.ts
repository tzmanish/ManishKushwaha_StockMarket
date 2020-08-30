import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Models/user';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  user:User;

  constructor(private service: AccountService) { }

  ngOnInit(): void {
    this.user = this.service.getUserData();
  }

}
