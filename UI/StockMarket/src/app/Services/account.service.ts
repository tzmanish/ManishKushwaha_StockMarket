import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../Models/user';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  path:string = environment.gatewayURL;

  constructor(private http:HttpClient, public jwtHelper: JwtHelperService) { }

  public authenticate(user:User): Observable<any> {
    return this.http.post<any>(`${this.path}/Account/Validate`, user);
  }

  public register(user:User): Observable<string> {
    return this.http.post(`${this.path}/Account/Add`, user, {responseType: 'text'});
  }

  public isTaken(username:string):Observable<boolean>{
    return this.http.get<boolean>(`${this.path}/Account/isTaken/${username}`);
  }

  public isAuthenticated():boolean{
    let token:string = JSON.parse(localStorage.getItem("session"))?.token;
    return !this.jwtHelper.isTokenExpired(token);
  }

  public logout():void{
    localStorage.clear();
  }
}
