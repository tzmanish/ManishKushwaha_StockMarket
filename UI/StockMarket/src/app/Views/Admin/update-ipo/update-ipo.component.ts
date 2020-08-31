import { Component, OnInit } from '@angular/core';
import { IPODetails } from 'src/app/Models/ipodetails';
import { AdminService } from 'src/app/Services/admin.service';
import { Company } from 'src/app/Models/company';
import { FlashMessagesService } from 'angular2-flash-messages';

@Component({
  selector: 'app-update-ipo',
  templateUrl: './update-ipo.component.html',
  styleUrls: ['./update-ipo.component.css']
})
export class UpdateIPOComponent implements OnInit {
  ipos:IPODetails[];
  companies:Company[];
  exchanges:string[];
  newIpo:IPODetails = <IPODetails>{};
  adding:boolean;
  log = console.log;

  constructor(private service:AdminService, private flashMessage: FlashMessagesService) { }

  ngOnInit(): void {
    this.service.reloadIpos.subscribe(()=>this.getAllIpos());
    this.service.getCompanies().subscribe(C=>this.companies=C);
    this.getAllIpos();
  }
  
  public updateIpo(ipo:IPODetails):void{
    this.service.updateIpo(ipo).subscribe(()=>this.resetAddForm(), err=>console.log(err));
  }
  
  public addIpo(ipo:IPODetails):void{
    this.service.addIpo(ipo).subscribe(()=>{
      this.flashMessage.show("IPO added", {cssClass: 'alert-success', timeout: 4000});
    });
    this.resetAddForm();
  }

  public resetAddForm():void{
    this.newIpo = <IPODetails>{};
    this.adding = true;
  }

  getAllIpos() {
    this.service.getIpos()
      .subscribe(ipos=>this.ipos=ipos);
  }

  editIpo(ipo:IPODetails):void{
    this.resetAddForm();
    this.adding = false;
    this.newIpo = Object.assign({}, ipo);
    this.updateExchanges(this.newIpo.companyCode);
    this.newIpo.formVisible = true;
    document.getElementById("ipoForm")?.scrollIntoView({behavior:"smooth"});
  }

  updateExchanges(companyCode:string){
    this.exchanges =  this.companies
      .find(C=>C.companyCode==companyCode)
      .stockExchanges?.split(",").map(E=>E.trim());
  }

}
