import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormArray, ReactiveFormsModule, Validators } from '@angular/forms';
import { ContactUsService } from 'src/shared/contact-us.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent implements OnInit {
  
  public contactForm : any;
  myFlag = false;
  firstname = ''
  ngOnInit(): void {

    this.contactForm= this.fb.group(
      {
        firstname : ['', [Validators.required, Validators.minLength(3)]],
        lastname : ['', [Validators.required, Validators.minLength(1)]],
        city : ['', [Validators.required, Validators.minLength(1)]],
        subject : ['', [Validators.required, Validators.minLength(3)]],
      },
    
    );
    
  }

  constructor(private fb : FormBuilder, private contactUsService : ContactUsService )
  {

  }

  reset()
  {
    this.contactForm.reset();
  }

  submit()
  {
    console.log("Contact form Submit click")
    console.log(this.contactForm.value);
    this.contactUsService.contactUsFromUser(this.contactForm.value).
    subscribe(
      (Response) =>
        {
          this.myFlag = true;
          console.log("Contact us data response");
          this.reset();
          
         },
        (error) =>
        {
            
            console.log("Log In Error");
           
        }

    )
    
    
  }

}
