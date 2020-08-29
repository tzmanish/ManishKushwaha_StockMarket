import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { User } from '../Models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  path:string = environment.gatewayURL;

  constructor(private http:HttpClient) { }

  public authenticate(user:User): Observable<any> {
    return this.http.post(`${this.path}/Account/Validate`, user);
  }

  public register(user:User): Observable<any> {
    return this.http.post(`${this.path}/Account/Add`, user);
  }

  public isTaken(username:string):Observable<boolean>{
    return this.http.get<boolean>(`${this.path}/Account/isTaken/${username}`);
  }

  public isLoggedIn():Observable<boolean>{
    return this.http.get<any>(`${this.path}/Account/Validate`, {headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer '+JSON.parse(localStorage.getItem("session"))?.token
    })});
  }
}
