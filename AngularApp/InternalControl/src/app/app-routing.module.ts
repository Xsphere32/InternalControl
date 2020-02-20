import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {TypeofformComponent} from './Components/typeofform/typeofform.component';
import {GroupofindicatorsComponent} from './Components/groupofindicators/groupofindicators.component';
import { IndicatorsComponent } from './Components/indicators/indicators.component';
import { QuestionComponent } from './Components/question/question.component';


const routes: Routes = [
  {path: 'TypeOfForms', component: TypeofformComponent},
  {path: 'GroupOfIndicators', component: GroupofindicatorsComponent},
  {path: 'Indicators', component: IndicatorsComponent},
  {path: 'Question', component: QuestionComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
