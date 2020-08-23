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

  public authenticate(username:string, password:string):Observable<User> {
    return this.http.get<User>(`${this.path}/Account/Validate/${username}/${password}`);
  }
}