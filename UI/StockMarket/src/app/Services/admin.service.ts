import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpBackend } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { Company } from '../Models/company';
import { IPODetails } from '../Models/ipodetails';
import { AccountService } from './account.service';
import { StockPrice } from '../Models/stock-price';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  path:string = environment.gatewayURL;

  private _reloadCompanies = new Subject<void>();
  get reloadCompanies(){return this._reloadCompanies;}

  constructor(private http:HttpClient, private handler: HttpBackend, private service: AccountService) { }

  public getCompanies():Observable<Company[]>{
    return this.http.get<Company[]>(`${this.path}/Admin/Companies/All`);
  }

  public updateCompany(company:Company):Observable<any>{
    return this.http.put<any>(
      `${this.path}/Admin/Companies/Update`, 
      JSON.stringify(company)
    ).pipe( tap(()=>{this._reloadCompanies.next();}) );
  }

  public deleteCompany(id:string):Observable<Company>{
    return this.http
      .delete<Company>(`${this.path}/Admin/Companies/${id}`)
      .pipe( tap(()=>{this._reloadCompanies.next();}) );
  }

  public addCompany(company:Company):Observable<any>{
    return this.http
      .post<any>(`${this.path}/Admin/Companies/add`, company)
      .pipe( tap(()=>{this._reloadCompanies.next();}) );
  }
  
  public isTaken(companyCode:string):Observable<boolean>{
    return this.http.get<boolean>(`${this.path}/Admin/Companies/isTaken/${companyCode}`);
  }



  public importExcel(fileToUpload:File, worksheetName:string):Observable<StockPrice[]>{
    const formData: FormData = new FormData();
    formData.append('ExcelFile', fileToUpload, fileToUpload.name);
    formData.set('Worksheet', worksheetName);

    const http:HttpClient = new HttpClient(this.handler);
    const options = { headers: new HttpHeaders({
      'Authorization': 'Bearer ' + this.service.getAuthToken()
    })};

    return http.post<StockPrice[]>(`${this.path}/Excel/Upload`, formData, options);
  }

  public downloadSample():Observable<Blob>{
    return this.http.get(`${this.path}/Excel/Sample`, {responseType: 'blob'});
  }

  
  private _reloadIpos = new Subject<void>();
  get reloadIpos(){return this._reloadIpos;}

  public getIpos():Observable<IPODetails[]>{
    return this.http.get<IPODetails[]>(`${this.path}/Admin/IPO/All`);
  }
  
  public addIpo(ipo:IPODetails):Observable<any>{
    return this.http
      .post<any>(`${this.path}/Admin/IPO/Add`, ipo)
      .pipe( tap(()=>{this._reloadIpos.next();}) );
  }
  
  public updateIpo(ipo:IPODetails):Observable<any>{
    return this.http.put<any>(
      `${this.path}/Admin/IPO/Update`, 
      JSON.stringify(ipo)
    ).pipe( tap(()=>{this._reloadIpos.next();}) );
  }


  public getMissingSP(companyCode:string, startDate:Date, endDate:Date):Observable<Date[]>{
    return this.http.get<Date[]>(
      `${this.path}/Admin/StockPrices/Missing/${companyCode}/${startDate}/${endDate}`
    );
  }
}
