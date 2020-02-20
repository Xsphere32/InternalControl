import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { GroupOfIndicators } from '../Models/groupOfIndicatorsModel';
import {TypeOfForm} from '../Models/typeOfFormModel';
import { PostFilter } from '../Models/postFiltersModel';

@Injectable({
  providedIn: 'root'
})
export class GroupOfIndicatorService {

  constructor(private httpClient : HttpClient) { }

  /**
   * Метод получения всех типов показателей из API
   */
  public Get() {
    return this.httpClient.get<GroupOfIndicators[]>(`${BaseUrl}groupOfIndicators`);
  }

  /**
   * Метод отправки данных в API
   */
  public Post(groupofindicator: GroupOfIndicators){
    const requestBody = JSON.stringify(groupofindicator);
    return this.httpClient.post<TypeOfForm>(`${BaseUrl}groupOfIndicators`, requestBody,
      {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe(resp => console.log(resp), err => {
      console.log(err);
    });
  }

  /**
   * PostFilters
   */
  public PostFilters(filter: PostFilter) {
    var requestBody = JSON.stringify(filter);
    return this.httpClient.post<GroupOfIndicators[]>(`${BaseUrl}groupOfIndicators/filter`, requestBody,
    {headers: new HttpHeaders({'Content-Type': 'application/json'}),});
  }
}
