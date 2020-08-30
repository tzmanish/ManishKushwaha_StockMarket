import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { AccountService } from '../Services/account.service';

@Injectable()

export class AuthInterceptor implements HttpInterceptor {
    constructor(private service: AccountService){}

    intercept(req:HttpRequest<any>, next:HttpHandler){
        const authToken:string = this.service.getAuthToken();
        req = req.clone({
            headers: req.headers
                .set('Authorization', 'Bearer ' + authToken)
                .set('Content-Type', 'application/json')
        });
        return next.handle(req);
    }
}
