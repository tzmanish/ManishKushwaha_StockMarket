import { Component, OnInit } from '@angular/core';
import { IPODetails } from 'src/app/Models/ipodetails';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-ipo',
  templateUrl: './ipo.component.html',
  styleUrls: ['./ipo.component.css']
})
export class IPOComponent implements OnInit {
  ipos:IPODetails[] = [];
  ipp:number = 10;
  pg:number = 1;
  more:boolean = true;
  all:boolean = false;

  constructor(private service: UserService) { }

  ngOnInit(): void {
    this.getItems();
  }

  getItems(){
    this.service.getIpos(this.pg, this.ipp, this.all).subscribe(I=>{
      this.ipos.push(...I);
      this.pg++;
      if(I.length < this.ipp) this.more = false;
    }, ()=>{this.more = false;});
  }

  toggle(){
    this.pg=1; 
    this.more=true; 
    this.ipos=[]; 
    this.getItems()
  }

}
