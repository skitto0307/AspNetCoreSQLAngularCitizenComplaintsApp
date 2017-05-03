import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule }      from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { MaterialModule } from './shared/material.module';
import { SharedModule }   from './shared/shared.module';

@NgModule({
  imports: [
    AppRoutingModule, 
    BrowserAnimationsModule,
    BrowserModule,
    CoreModule,
    MaterialModule,
    SharedModule,
  ],
  declarations: [
    AppComponent,
    AppRoutingModule.components,
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
