import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { AccountService } from './Services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'StockMarket';
  showNavbar:boolean = true;

  constructor(
    private service:AccountService
  ) { }

  ngOnInit():void{
    this.service.isLoggedIn().subscribe(()=>this.showNavbar=true, ()=>this.showNavbar=false);
  }
}
