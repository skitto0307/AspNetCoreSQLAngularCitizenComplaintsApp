import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    MaterialModule,
    CitizenComplaintsClientRoutingModule
  ],
  providers: [CitizenComplaintsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
