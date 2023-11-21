import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class QuestionService {
  baseURL: string = 'https://localhost:7022/api/exam/exam-questions';

  baseURLinsert:string='https://localhost:7022/api/question/insert';
  baseURLid:string='https://localhost:7022/api/exam/exam-questions';
  baseDelete:string='https://localhost:7022/api/question/delete';
  baseEditURL:string='https://localhost:7022/api/question/update';
  baseGetuestionById:string ='https://localhost:7022/api/question';
  constructor(private http: HttpClient) {}

  getQuestions(examId:any) {
    console.log(`${this.baseURL}/${examId}`);
    
    return this.http.get(`${this.baseURL}/${examId}`);
  }
  addQuestion(q:any){
    return this.http.post(`${this.baseURLinsert}`,q );
  }
  getquestionByExamID(examID:any){
    return this.http.get(`${this.baseURLid}/`,examID);
  }
  Delete(ID:any){
    return this.http.delete(`${this.baseDelete}/${ID}`);
  };
  Edit(data:any){
    return this.http.put(`${this.baseEditURL}`,data);
  }
  getestionByIDElement(id:any){
    return this.http.get(`${this.baseGetuestionById}/${id}`);
  }



}
