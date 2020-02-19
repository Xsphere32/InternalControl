import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { Indicator } from '../Models/indicatorModel';

@Injectable({
  providedIn: 'root'
})
export class IndicatorsService {

  constructor(private httpClient : HttpClient) { }

  /**
   * Метод получения всех показателей из API
   */
  public GetQuestions() {
    var response = this.httpClient.get(`${BaseUrl}indicators/get`);
  }

  /**
   * Метод отправки данных в API
   */
  public PostQuestion(indicator: Indicator){
    var requestBody = JSON.stringify(indicator);
    this.httpClient.post(`${BaseUrl}indicators/post`, requestBody)
  }
}
