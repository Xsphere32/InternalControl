import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { Question } from '../Models/questionModel';
import { PostFilter } from '../Models/postFiltersModel';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {

  constructor(private httpClient : HttpClient) { }

  /**
   * Метод получения всех вопросов из API
   */
  public GetQuestions() {
    return this.httpClient.get<Question[]>(`${BaseUrl}questions`);
  }

  /**
   * Метод отправки данных в API
   */
  public PostQuestion(question: Question){
    var requestBody = JSON.stringify(question);
    this.httpClient.post(`${BaseUrl}questions`, requestBody,
    {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe(resp => console.log(resp), err => {
    console.log(err);})
  }

  /**
   * PostFilters
   */
  public PostFilters(filter: PostFilter) {
    var requestBody = JSON.stringify(filter);
    return this.httpClient.post<Question[]>(`${BaseUrl}questions/filter`, requestBody,
    {headers: new HttpHeaders({'Content-Type': 'application/json'})});
  }
}
