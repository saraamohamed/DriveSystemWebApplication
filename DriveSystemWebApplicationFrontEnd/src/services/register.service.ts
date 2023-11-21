import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  bseUrl:string="https://localhost:7022/api/user/insert"
  
  
  
  constructor(private http:HttpClient) { }
  
  
  Register(data:any){
    return this.http.post(`${this.bseUrl}`,data);
  }
}
