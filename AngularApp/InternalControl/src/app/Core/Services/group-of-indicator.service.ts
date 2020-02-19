import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { GroupOfIndicators } from '../Models/groupOfIndicatorsModel';

@Injectable({
  providedIn: 'root'
})
export class GroupOfIndicatorService {

  constructor(private httpClient : HttpClient) { }

  /**
   * Метод получения всех типов показателей из API
   */
  public GetQuestions() {
    var response = this.httpClient.get(`${BaseUrl}groupofindicator/get`);
  }

  /**
   * Метод отправки данных в API
   */
  public PostQuestion(groupofindicator: GroupOfIndicators){
    var requestBody = JSON.stringify(groupofindicator);
    this.httpClient.post(`${BaseUrl}groupofindicator/post`, requestBody)
  }
}
