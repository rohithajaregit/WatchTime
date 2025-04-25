import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../header/header.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  
  username = '';
  loginstatus: boolean = false;
  ngOnInit(): void {

    let data = localStorage.getItem('CurrentUser');
    
    if(data)
      {
          this.username = JSON.parse(localStorage.getItem('CurrentUser')!);
          this.loginstatus = false;
      }
  }

  

}
