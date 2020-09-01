import { Injectable } from '@angular/core';
import { IPODetails } from '../Models/ipodetails';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Company } from '../Models/company';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  path:string = environment.gatewayURL;

  constructor(private http:HttpClient) { }
  
  public getIpos(pg:number, ipp:number):Observable<IPODetails[]>{
    return this.http.get<IPODetails[]>(`${this.path}/User/IPO/${pg}/${ipp}`);
  }

  public getCompanies():Observable<Company[]>{
    return this.http.get<Company[]>(`${this.path}/User/Companies/All`);
  }
}
