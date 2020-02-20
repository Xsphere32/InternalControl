import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/Core/Models/questionModel';
import { Indicator } from 'src/app/Core/Models/indicatorModel';
import { GroupOfIndicators } from 'src/app/Core/Models/groupOfIndicatorsModel';
import { TypeOfForm } from 'src/app/Core/Models/typeOfFormModel';
import { TypeOfFormsService } from 'src/app/Core/Services/type-of-forms.service';
import { GroupOfIndicatorService } from 'src/app/Core/Services/group-of-indicator.service';
import { IndicatorsService } from 'src/app/Core/Services/indicators.service';
import { QuestionsService } from 'src/app/Core/Services/questions.service';
import { PostFilter } from 'src/app/Core/Models/postFiltersModel';

@Component({
  selector: 'app-forms',
  templateUrl: './forms.component.html',
  styleUrls: ['./forms.component.css']
})
export class FormsComponent implements OnInit {

  formQuestions: Question[];
  question: Question = new Question();
  indicator: Indicator = new Indicator();
  groupOfIndicators: GroupOfIndicators = new GroupOfIndicators();
  typeOfForm: TypeOfForm = new TypeOfForm();
  typesOfForm: TypeOfForm[];
  groupsOfIndicators: GroupOfIndicators[];
  indicartors: Indicator[];
  questions: Question[];
  filter: PostFilter = new PostFilter();

  constructor(private typesOfFormService: TypeOfFormsService,
              private groupOfIndicatorsService: GroupOfIndicatorService,
              private indicatorsService: IndicatorsService,
              private questionService: QuestionsService) { }

  ngOnInit() {
    this.formQuestions.push(new Question());
  }

  onHide(){
    this.filter.TypeOfForm = this.typeOfForm;
    this.questionService.PostFilters(this.filter).subscribe(resp => this.questions = resp,
      err => console.warn(err));
  }

}
