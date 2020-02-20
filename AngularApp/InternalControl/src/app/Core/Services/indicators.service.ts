import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { Indicator } from '../Models/indicatorModel';
import { PostFilter } from '../Models/postFiltersModel';

@Injectable({
  providedIn: 'root'
})
export class IndicatorsService {

  constructor(private httpClient : HttpClient) { }

  /**
   * Метод получения всех показателей из API
   */
  public Get() {
    return this.httpClient.get<Indicator[]>(`${BaseUrl}indicators`);
  }

  /**
   * Метод отправки данных в API
   */
  public Post(indicator: Indicator){
    var requestBody = JSON.stringify(indicator);
    this.httpClient.post(`${BaseUrl}indicators`, requestBody,
    {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe(resp => console.log(resp), err => {
    console.log(err);})
  }

  /**
   * PostFilters
   */
  public PostFilters(filter: PostFilter) {
    var requestBody = JSON.stringify(filter);
    return this.httpClient.post<Indicator[]>(`${BaseUrl}indicators/filter`, requestBody,
    {headers: new HttpHeaders({'Content-Type': 'application/json'})});
  }
}
