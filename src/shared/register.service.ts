import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  public HOSTING:string = 'http://localhost:5071/';
  readonly registrationURL:string =  this.HOSTING + 'Register/registeruser'

  constructor(private http : HttpClient) { }

  registerNewUser(userData : any) : Observable<any>
  {
    console.log("Registration for new user");
    return this.http.post(this.registrationURL, userData);

  }
}
