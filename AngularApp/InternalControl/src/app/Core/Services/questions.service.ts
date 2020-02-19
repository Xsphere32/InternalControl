import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { Question } from '../Models/questionModel';

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
    this.httpClient.post(`${BaseUrl}questions/post`, requestBody)
  }
}
