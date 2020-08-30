import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/Models/company';
import { AdminService } from 'src/app/Services/admin.service';

@Component({
  selector: 'app-manage-company',
  templateUrl: './manage-company.component.html',
  styleUrls: ['./manage-company.component.css']
})
export class ManageCompanyComponent implements OnInit {
  companies:Company[];
  newCompany:Company = <Company>{};
  adding:boolean = true;
  iscodetaken:boolean = false;

  constructor(private service:AdminService) { }

  ngOnInit(): void {
    this.service.timeToReload.subscribe(()=>this.getAllCompanies());
    this.getAllCompanies();
  }

  public getAllCompanies(){
    this.service.getCompanies()
      .subscribe(companies=>this.companies=companies, err=>console.log(err));
  }

  public updateCompany(company:Company):void{
    this.service.updateCompany(company).subscribe(()=>this.resetAddForm(), err=>console.log(err));
  }

  public deleteCompany(companyCode:string):void{
    if(confirm(`This action wil delete ${companyCode} permanently! Are you sure?"`))
    this.service.deleteCompany(companyCode).subscribe(res=>{
      console.log(res);
    }, err=>console.log(err));
  }

  public addCompany(company:Company):void{
    this.service.addCompany(company).subscribe(()=>{}, err=>console.log(err));
    this.resetAddForm();
  }

  public resetAddForm():void{
    this.newCompany = <Company>{};
    this.adding = true;
  }

  public isCodeTaken():void{
    this.service.isTaken(this.newCompany.companyCode)
      .subscribe(taken=>this.iscodetaken =  (taken === true), err=>{
        this.iscodetaken = false;   //Can't check.
        console.log(err);
      });
  }
  public editCompany(company:Company):void{
    this.resetAddForm();
    this.adding = false;
    this.newCompany = Object.assign({}, company);
    this.newCompany.formVisible = true;
    document.getElementById("companyForm")?.scrollIntoView({behavior:"smooth"});
  }
}
