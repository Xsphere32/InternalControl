import { Component, OnInit } from '@angular/core';
import { GroupOfIndicators } from 'src/app/Core/Models/groupOfIndicatorsModel';
import { TypeOfForm } from 'src/app/Core/Models/typeOfFormModel';
import { TypeOfFormsService } from 'src/app/Core/Services/type-of-forms.service';
import { GroupOfIndicatorService } from 'src/app/Core/Services/group-of-indicator.service';
import { IndicatorsService } from 'src/app/Core/Services/indicators.service';
import { Indicator } from 'src/app/Core/Models/indicatorModel';
import { PostFilter } from 'src/app/Core/Models/postFiltersModel';

@Component({
  selector: 'app-indicators',
  templateUrl: './indicators.component.html',
  styleUrls: ['./indicators.component.css']
})
export class IndicatorsComponent implements OnInit {

  typesOfForm: TypeOfForm[];
  typeOfForm: TypeOfForm = new TypeOfForm;
  groupsOfIndicators: GroupOfIndicators[];
  groupOfIndicators: GroupOfIndicators;
  indicator: Indicator = new Indicator();
  
  constructor(private typesOfFormService: TypeOfFormsService,
              private groupOfIndicatorsService: GroupOfIndicatorService,
              private indicatorsService: IndicatorsService) { }

  ngOnInit() {
    this.typesOfFormService.GetTypes().subscribe(resp => this.typesOfForm = resp, err => console.warn(err));
    this.groupOfIndicatorsService.Get().subscribe(resp => this.groupsOfIndicators = resp, err => console.warn(err));
  }

  submit(){
    if (this.indicator.Name && this.typeOfForm && this.groupOfIndicators){
      this.indicator.GroupOfIndicators = this.groupOfIndicators;
      this.indicator.TypeOfForm = this.typeOfForm;
      this.indicatorsService.Post(this.indicator);
      alert(`Создано + ${this.indicator.Name}`);
    } else {
      alert('Укажите название и/или выберите предшествующие значения!');
      return;
    }
  }

  onTypesChange(){
    let Filter: PostFilter = new PostFilter();
    Filter.TypeOfForm = this.typeOfForm;
    this.groupOfIndicatorsService.PostFilters(Filter).subscribe(resp => this.groupsOfIndicators = resp);
    return;
  }

}
