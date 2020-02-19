import { Component, OnInit } from '@angular/core';
import {TypeOfForm} from '../../Core/Models/typeOfFormModel';
import {TypeOfFormsService} from '../../Core/Services/type-of-forms.service';
import {GroupOfIndicatorService} from '../../Core/Services/group-of-indicator.service';
import {GroupOfIndicators} from '../../Core/Models/groupOfIndicatorsModel';

@Component({
  selector: 'app-groupofindicators',
  templateUrl: './groupofindicators.component.html',
  styleUrls: ['./groupofindicators.component.css']
})
export class GroupofindicatorsComponent implements OnInit {

  typesOfForm: TypeOfForm[];
  typeOfForm: TypeOfForm;
  groupOfIndicators: GroupOfIndicators = new GroupOfIndicators();

  constructor(private typeOfFormService: TypeOfFormsService,
              private groupOfIndicatorsService: GroupOfIndicatorService) { }

  ngOnInit() {
    this.typeOfFormService.GetTypes().subscribe(resp => {
      this.typesOfForm = resp;
    });
  }

  click() {
    if (this.typeOfForm === null) {
      alert('Укажите тип анкеты!')
      return;
    } else {
      this.groupOfIndicatorsService.PostQuestion(this.groupOfIndicators);
      return;
    }
  }

}
