import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsernameService {

  public buttonTextSource = new BehaviorSubject<string>('Login');
  currentButtonText = this.buttonTextSource.asObservable();

  constructor() { }

   updateButtonText(newText: string) {
    this.buttonTextSource.next(newText);
}
}