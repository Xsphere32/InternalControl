import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { BaseUrl } from '../Constants/Constants';
import { TypeOfForm } from '../Models/typeOfFormModel';
import {catchError} from 'rxjs/operators';
import {error} from 'util';

@Injectable({
  providedIn: 'root'
})
export class TypeOfFormsService {

  constructor(private httpClient: HttpClient) { }

  /**
   * Метод получения всех типов анкет из API
   */
  public GetTypes() {
    return this.httpClient.get<TypeOfForm[]>(`${BaseUrl}typeofform`);
  }

  /**
   * Метод отправки данных в API
   */
  public PostQuestion(typeofform: TypeOfForm) {
    const requestBody = JSON.stringify(typeofform);
    console.log(requestBody);
    return this.httpClient.post<TypeOfForm>(`${BaseUrl}typeofform`, requestBody,
      {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe(resp => console.log(resp), err => {
        console.log(err);
    });
  }
}
