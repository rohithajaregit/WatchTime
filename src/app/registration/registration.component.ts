import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormArray, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegisterService } from 'src/shared/register.service';
import { ToastrService } from 'ngx-toastr';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  
  public registrationform : any;
  public infoMessage: any = '';
  registerFlag = false;
  get email()
 {
    return this.registrationform.get('email');
 }
 get password()
 {
    return this.registrationform.get('password');
 }
 get confirmpassword()
 {
    return this.registrationform.get('confirmpassword');
 }
 get mobilenumber()
 {
   return this.registrationform.get('mobilenumber');
 }
  ngOnInit(): void{
    
    
    this.registrationform = this.fb.group(
      {
        firstname : ['', [Validators.required, Validators.minLength(3)]],
        lastname : ['', [Validators.required, Validators.minLength(1)]],
        email : ['', [Validators.required, Validators.minLength(1)]],
        mobilenumber : ['', [Validators.required, Validators.minLength(10)]],
        username : ['', [Validators.required, Validators.minLength(3)]],
        password : ['', [Validators.required]],
        confirmpassword : ['', [Validators.required]],
      },
    
    );
  }

  constructor(private fb : FormBuilder, private registerObj : RegisterService, private toastr : ToastrService)
  {

  }

  reset()
  {
    this.registrationform.reset();
  }

  onSubmit()
  {
    
    this.registerObj.registerNewUser(this.registrationform.value).
    subscribe(
      (Response) =>
      {
        console.log("Response from new user");
        this.toastr.success("Registration Successful ");
        this.registerFlag = true;
        this.reset();
      },
      (error) =>
      {
          console.log("error from register");
      }
      
    )
  }

  ConfirmedValidator(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls['password'];
      const matchingControl = formGroup.controls[matchingControlName];
      if (
        matchingControl.errors &&
        !matchingControl.errors?.['confirmedValidator']
      ) {
        return;
      }
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ confirmedValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }

}
