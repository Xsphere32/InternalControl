import { Component, OnInit } from '@angular/core';
import {TypeOfForm} from '../../Core/Models/typeOfFormModel';

@Component({
  selector: 'app-typeofform',
  templateUrl: './typeofform.component.html',
  styleUrls: ['./typeofform.component.css']
})
export class TypeofformComponent implements OnInit {

  typeOfForm: TypeOfForm;
  constructor() { }

  ngOnInit() {
  }

}
