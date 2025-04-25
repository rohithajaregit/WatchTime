import { Component, EventEmitter, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { LoginService } from 'src/shared/login.service';
import { UsernameService } from 'src/shared/username.service';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  
  public buttonText : any;
  
  ngOnInit(): void {

    this.username.currentButtonText.subscribe(
        (text) => (this.buttonText = text)
      );
         
    }


  constructor(private router : Router, private username : UsernameService)
  {
    this.buttonText = "Login";
  }

}
