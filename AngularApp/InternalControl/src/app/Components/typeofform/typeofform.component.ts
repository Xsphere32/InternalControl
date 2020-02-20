import { Component, OnInit } from '@angular/core';
import {TypeOfForm} from '../../Core/Models/typeOfFormModel';
import {TypeOfFormsService} from '../../Core/Services/type-of-forms.service';

@Component({
  selector: 'app-typeofform',
  templateUrl: './typeofform.component.html',
  styleUrls: ['./typeofform.component.css']
})
export class TypeofformComponent implements OnInit {

  typeOfForm: TypeOfForm = new TypeOfForm();
  constructor(private typeOfFormsService: TypeOfFormsService) { }

  ngOnInit() {
  }

  SendModel() {
    this.typeOfFormsService.PostQuestion(this.typeOfForm);
    alert('Создано' + this.typeOfForm);
  }

}
