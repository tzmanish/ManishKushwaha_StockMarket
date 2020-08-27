import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { User } from '../Models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  path:string = environment.gatewayURL;

  constructor(private http:HttpClient) { }

  public authenticate(user:User) {
    return this.http.post(`${this.path}/Account/Validate`, user, {responseType: 'text'});
  }

  public register(user:User) {
    return this.http.post(`${this.path}/Account/Add`, user);
  }

  public isTaken(username:string):Observable<boolean>{
    return this.http.get<boolean>(`${this.path}/Account/isTaken/${username}`);
  }
}
