import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Observable, Subject } from 'rxjs';
import { Company } from '../Models/company';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  path:string = environment.gatewayURL;

  private _timeToReload = new Subject<void>();
  get timeToReload(){return this._timeToReload;}

  constructor(private http:HttpClient) { }

  public getCompanies():Observable<Company[]>{
    return this.http.get<Company[]>(`${this.path}/Admin/Companies/All`);
  }

  public updateCompany(company:Company):Observable<any>{
    return this.http.put<any>(
      `${this.path}/Admin/Companies/Update`, 
      JSON.stringify(company)
    ).pipe( tap(()=>{this._timeToReload.next();}) );
  }

  public deleteCompany(id:string):Observable<any>{
    return this.http
      .delete<any>(`${this.path}/Admin/Companies/${id}`)
      .pipe( tap(()=>{this._timeToReload.next();}) );
  }

  public addCompany(company:Company):Observable<any>{
    return this.http
      .post<any>(`${this.path}/Admin/Companies/add`, company)
      .pipe( tap(()=>{this._timeToReload.next();}) );
  }
  
  public isTaken(companyCode:string):Observable<boolean>{
    return this.http.get<boolean>(`${this.path}/Admin/Companies/isTaken/${companyCode}`);
  }
}
