import { Component, OnInit } from '@angular/core';
import { Indicator } from 'src/app/Core/Models/indicatorModel';
import { TypeOfForm } from 'src/app/Core/Models/typeOfFormModel';
import { GroupOfIndicators } from 'src/app/Core/Models/groupOfIndicatorsModel';
import { QuestionsService } from 'src/app/Core/Services/questions.service';
import { TypeOfFormsService } from 'src/app/Core/Services/type-of-forms.service';
import { GroupOfIndicatorService } from 'src/app/Core/Services/group-of-indicator.service';
import { IndicatorsService } from 'src/app/Core/Services/indicators.service';
import { Question } from 'src/app/Core/Models/questionModel';
import { PostFilter } from 'src/app/Core/Models/postFiltersModel';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  typesOfForm: TypeOfForm[];
  typeOfForm: TypeOfForm;
  groupsOfIndicators: GroupOfIndicators[];
  groupOfIndicators: GroupOfIndicators;
  indicartors: Indicator[];
  indicator: Indicator;
  question: Question = new Question();
  questions: Question[];

  constructor(private typesOfFormService: TypeOfFormsService,
              private groupOfIndicatorsService: GroupOfIndicatorService,
              private indicatorsService: IndicatorsService,
              private questionService: QuestionsService) { }

  ngOnInit() {
    this.typesOfFormService.GetTypes().subscribe(resp => this.typesOfForm = resp, err => console.error(err));
    this.groupOfIndicatorsService.Get().subscribe(resp => this.groupsOfIndicators = resp, err => console.error(err));
    this.indicatorsService.Get().subscribe(resp => this.indicartors = resp, err => console.error(err));
    this.questionService.GetQuestions().subscribe(resp=> this.questions = resp);
  }

  submit(){
    if (this.question.Name && this.typeOfForm && this.groupOfIndicators && this.indicator){
      this.question.GroupOfIndicators = this.groupOfIndicators;
      this.question.TypeOfForm = this.typeOfForm;
      this.question.Indicators = this.indicator;
      this.questionService.PostQuestion(this.question);
      alert(`Создано ${this.question.Name}`);
      this.getQuestions();
      this.question.Name = '';
    } else {
      alert('Укажите название и/или выберите предшествующие значения!');
      return;
    }
  }
  
  getQuestions(){
    this.questionService.GetQuestions().subscribe(resp=> this.questions = resp);
  }

  onTypesChange(){
    let Filter: PostFilter = new PostFilter();
    Filter.TypeOfForm = this.typeOfForm;
    this.groupOfIndicatorsService.PostFilters(Filter).subscribe(resp => this.groupsOfIndicators = resp);
    return;
  }

  onGroupsChange(){
    let Filter: PostFilter = new PostFilter();
    Filter.TypeOfForm = this.typeOfForm;
    Filter.GroupOfIndicators = this.groupOfIndicators;
    this.groupOfIndicatorsService.PostFilters(Filter).subscribe(resp => this.groupsOfIndicators = resp);
    return;
  }

}
