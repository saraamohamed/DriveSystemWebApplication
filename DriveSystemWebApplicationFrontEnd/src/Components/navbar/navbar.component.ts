import { Component, OnInit, DoCheck } from '@angular/core';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements DoCheck {

  token: any;
  role: any;
  tokenData: any
  isLogged = false;
  isUser = false;
  isAdmin = false;
  constructor(private router: Router) { }

  ngDoCheck(): void {
    this.token = localStorage.getItem("token");

    if (this.token != null) {
      this.tokenData = jwt_decode(this.token);
      this.role = this.tokenData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]

      if (this.token != null) {

        this.isLogged = true;
        if (this.role == "user") {
          this.isUser = true;
        }
        if (this.role == "admin") {
          this.isAdmin = true;
        }
      }
    }

  }

  signOut() {

    localStorage.clear()
    this.isLogged = false;
    this.isUser = false;
    this.isAdmin = false;
    this.router.navigate(['/Home']);

  }

}