import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NavbarComponent } from './ui/navbar/navbar.component';
import { PhonePipe } from './pipes/phone.pipe';

@NgModule({
  imports: [ CommonModule, FormsModule, ReactiveFormsModule ],
  declarations: [ NavbarComponent, PhonePipe ],
  exports: [ CommonModule, FormsModule, ReactiveFormsModule, NavbarComponent, PhonePipe ]
})
export class SharedModule { }