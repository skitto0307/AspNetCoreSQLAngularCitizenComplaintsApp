import { NgModule } from '@angular/core';

import { MdButtonModule, MdInputModule, MdTabsModule, MdIconModule, MdSelectModule, MdCardModule } from '@angular/material';

const mdModules = [MdButtonModule, MdInputModule, MdTabsModule, MdIconModule, MdSelectModule, MdCardModule];

@NgModule({
  imports: [...mdModules],
  exports: [...mdModules],
})
export class MaterialModule { }