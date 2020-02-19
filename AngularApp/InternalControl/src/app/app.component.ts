import { Component } from '@angular/core';
import { QuestionsService } from './Core/Services/questions.service';
import { Question } from './Core/Models/questionModel';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private questionsService : QuestionsService) {
    
  }

  a : Question[];
  ngOnInit(){
    this.questionsService.GetQuestions().subscribe(res => this.a = res);
  }
  
}
