import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { TypeOfForm } from '../Models/typeOfFormModel';

@Injectable({
  providedIn: 'root'
})
export class TypeOfFormsService {

  constructor(private httpClient : HttpClient) { }

  /**
   * Метод получения всех типов анкет из API
   */
  public GetQuestions() {
    var response = this.httpClient.get(`${BaseUrl}typeofform/get`);
  }

  /**
   * Метод отправки данных в API
   */
  public PostQuestion(typeofform: TypeOfForm){
    var requestBody = JSON.stringify(typeofform);
    this.httpClient.post(`${BaseUrl}typeofform/post`, requestBody)
  }
}
