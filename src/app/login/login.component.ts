import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, ReactiveFormsModule,FormControl,FormGroup, FormArray,Validators } from '@angular/forms';
import { LoginService } from 'src/shared/login.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Token } from '@angular/compiler';
import { EventEmitter } from '@angular/core';
import { UsernameService } from 'src/shared/username.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  title = 'LogInForm';
  public logInForm : any;
  public isLogIn = true;
  @Output()
  emitterService: EventEmitter<Headers> = new EventEmitter<Headers>;

  get password()
  {
    return this.logInForm.get('password');
  }
  get username()
  {
    return this.logInForm.get('username');
  }
  ngOnInit(){
    
    this.logInForm  = this.fb.group(
      {
        username : ['', [Validators.required]],
        password : ['', [Validators.required]],
  
      },
    
    );

  }

  constructor(private fb : FormBuilder, private toast : ToastrService, private loginObj : LoginService, private router:Router, private usernameService : UsernameService)
  {
     
  }

  onsubmit()
  {
    this.loginObj.loginuser(this.logInForm.value).
    subscribe(
      (Response) =>
      {
        console.log("Response from LogIn");
        this.isLogIn = true;
       
        localStorage.setItem('CurrentUser', this.logInForm.value.username);
        this.emitterService.emit(this.logInForm.value.username);
        sessionStorage.setItem('loggedUser', this.logInForm.value.username);
        this.usernameService.updateButtonText(this.logInForm.value.username);
        this.router.navigate(['/Products']);
        
      },
      (error) =>
      {
          this.isLogIn = false;
          console.log("Log In Error");
      }
      
    )
    
    
  }

}
