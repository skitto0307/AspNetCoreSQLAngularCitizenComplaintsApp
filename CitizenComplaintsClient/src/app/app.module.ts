import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { MaterialModule } from '@angular/material';

import {CitizenComplaintsService,PhonePipe} from './shared';

import { AppComponent } from './app.component';

import { CitizenComplaintsClientRoutingModule, routedComponents } from './app-routing.module';


@NgModule({
  declarations: [
    AppComponent,
    routedComponents,
    PhonePipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    MaterialModule.forRoot(),
    CitizenComplaintsClientRoutingModule
  ],
  providers: [CitizenComplaintsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
