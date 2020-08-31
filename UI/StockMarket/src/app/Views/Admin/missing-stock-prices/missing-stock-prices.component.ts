import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/Services/admin.service';
import { StockPrice } from 'src/app/Models/stock-price';
import { Company } from 'src/app/Models/company';

@Component({
  selector: 'app-missing-stock-prices',
  templateUrl: './missing-stock-prices.component.html',
  styleUrls: ['./missing-stock-prices.component.css']
})
export class MissingStockPricesComponent implements OnInit {
  missingSP:Date[] = [];
  companies:Company[] = [];
  companyCode:string;
  start:Date;
  end:Date;

  constructor(private service: AdminService) { }

  ngOnInit(): void {
    this.service.getCompanies()
      .subscribe(C=>{this.companies=C});
  }

  public getMissingSP(){
    this.service.getMissingSP(this.companyCode, this.start, this.end)
      .subscribe(SP=>{this.missingSP=SP});
  }

}
