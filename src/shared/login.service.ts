import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  public HOSTING:string = 'http://localhost:5071/';
  readonly loginURL:string =  this.HOSTING + 'Login/login'

  constructor(private http : HttpClient) { }

  loginuser(userData : any) : Observable<any>
  {
    console.log("LogIn user");
    return this.http.post(this.loginURL, userData);

  }
}
