import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent {
  name: string = '';
  email: string = '';
  message: string = '';
  subject:string=''
  phone: string='';

  onSubmit(form: any) {
    if (form && form.value) {
      const { name, email, phone, message } = form.value;
      console.log(name, email, phone, message);
    }
  }
  constructor(private router: Router) {}
  
  contact() {

    // Navigate to home component
    this.router.navigate(['/home']);
  }
}