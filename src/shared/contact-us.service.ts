import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ContactUsService {

  public HOSTING:string = 'http://localhost:5071/';
  readonly contactUsURL:string =  this.HOSTING + 'ContactUs/contactus'

  constructor(private http : HttpClient) { }

  contactUsFromUser(userData : any) : Observable<any>
  {
    console.log("Contact US data");
    return this.http.post(this.contactUsURL, userData);

  }
}
