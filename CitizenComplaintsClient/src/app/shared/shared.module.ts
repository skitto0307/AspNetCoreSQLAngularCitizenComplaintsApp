import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { PhonePipe } from './pipes/phone.pipe';

@NgModule({
  imports: [ CommonModule, FormsModule, ReactiveFormsModule ],
  declarations: [ PhonePipe ],
  exports: [ CommonModule, FormsModule, ReactiveFormsModule, PhonePipe ]
})
export class SharedModule { }