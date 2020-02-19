import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TypeofformComponent } from './Components/typeofform/typeofform.component';
import { GroupofindicatorsComponent } from './Components/groupofindicators/groupofindicators.component';
import { IndicatorsComponent } from './Components/indicators/indicators.component';
import { QuestionComponent } from './Components/question/question.component';
import {FormsModule} from '@angular/forms';
import {ButtonModule} from 'primeng';

@NgModule({
  declarations: [
    AppComponent,
    TypeofformComponent,
    GroupofindicatorsComponent,
    IndicatorsComponent,
    QuestionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    ButtonModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
