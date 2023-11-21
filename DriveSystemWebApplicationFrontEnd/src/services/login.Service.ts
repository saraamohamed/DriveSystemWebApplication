import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  baseUrl: string = "https://localhost:7022/api/login";
  checklogin=false;
  res:any;
  constructor(private http: HttpClient) {}
  
  login(data: any) {
    return this.http.post(this.baseUrl, data, { observe: 'response' });
  }
  getStatus(response: HttpResponse<any>): number {
    this.res=response.status;
    if (this.res === 200) { // Check the status code
     this.checklogin=true;
     localStorage.setItem("checklogin",`${this.checklogin}`);
      console.log("Logged in successfully");
    }
    return this.res
  }

  checkUserLogin(){
    return localStorage.getItem("checklogin")
  }
}