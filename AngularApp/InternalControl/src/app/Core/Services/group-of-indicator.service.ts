import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { GroupOfIndicators } from '../Models/groupOfIndicatorsModel';
import {TypeOfForm} from '../Models/typeOfFormModel';

@Injectable({
  providedIn: 'root'
})
export class GroupOfIndicatorService {

  constructor(private httpClient : HttpClient) { }

  /**
   * Метод получения всех типов показателей из API
   */
  public GetQuestions() {
    this.httpClient.get(`${BaseUrl}groupOfIndicators`);
  }

  /**
   * Метод отправки данных в API
   */
  public PostQuestion(groupofindicator: GroupOfIndicators){
    const requestBody = JSON.stringify(groupofindicator);
    console.log(requestBody);
    return this.httpClient.post<TypeOfForm>(`${BaseUrl}groupOfIndicators`, requestBody,
      {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe(resp => console.log(resp), err => {
      console.log(err);
    });
  }
}
