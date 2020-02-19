import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {TypeofformComponent} from './Components/typeofform/typeofform.component';
import {GroupofindicatorsComponent} from './Components/groupofindicators/groupofindicators.component';


const routes: Routes = [
  {path: 'TypeOfForms', component: TypeofformComponent},
  {path: 'GroupOfIndicators', component: GroupofindicatorsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
