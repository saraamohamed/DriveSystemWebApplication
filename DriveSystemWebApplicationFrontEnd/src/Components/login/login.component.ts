import { Component } from '@angular/core';
import { FormGroup,FormControl ,Validators} from '@angular/forms';
import { LoginService } from 'src/services/login.Service';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

token:any
errorMessage: any;
  
  loginForm =new FormGroup({
    username: new FormControl('',[Validators.required]),
    password: new FormControl('',[Validators.required]),

})

get getUserName(){
  return this.loginForm.controls['username']
};get getPassword(){
  return this.loginForm.controls['password']
};

constructor(private router: Router,
  private loginService:LoginService) {}


  login() {
    const user = {
      username: this.loginForm.value.username,
      password: this.loginForm.value.password
    };
    
    this.loginService.login(user).subscribe({
      next: (response: HttpResponse<any>) => {
        const statusCode = this.loginService.getStatus(response);
        if (statusCode === 200) { // Check the status code
          this.token = response.body.token; // Extract the JWT token from the response body
          const tokenData = jwt_decode(this.token);
          console.log("Logged in successfully");
          localStorage.setItem("token", this.token); // Save the token to local storage
          this.router.navigate(['/Home']);
        } else {
          console.log("Login failed with status code: " + statusCode);
          this.router.navigate(['/login']);
        }
      },
      error: (error: any) => {
        console.error(error);
        this.errorMessage = "Invalid username or password.";
        this.router.navigate(['/login']);
      }
    });
    
   
  }

  

}
