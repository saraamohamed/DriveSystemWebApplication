import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
    baseURL: string = 'http://localhost:3000/Exams';

  constructor(private http: HttpClient) {}

  getAllExams() {
    return this.http.get(this.baseURL);
  }

  getExamById(userId: any) {
    return this.http.get(`${this.baseURL}?UserId=${userId}`);
  }

  addExam(user: any) {
    return this.http.post(this.baseURL,user);
  }

  deleteExam(userId: any) {
    return this.http.delete(`${this.baseURL}?UserId=${userId}`);
  }

  editExam(userId: any, user: any) {
    return this.http.put(`${this.baseURL}/${userId}`, user);
  }
}