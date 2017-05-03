import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {ComplaintsComponent} from './complaints/complaints.component';
import {ComplaintDetailsComponent} from './complaint-details/complaint-details.component';
//Todo: remove details and use form for add and update
import {ComplaintFormComponent} from './complaint-form/complaint-form.component';


const routes: Routes = [
  {path:'', redirectTo:'complaints', pathMatch:'full'},
  {path:'complaints', component:ComplaintsComponent},
  {path:'details/:id', component:ComplaintDetailsComponent},
  {path:'add', component:ComplaintFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  static components = [ComplaintsComponent,ComplaintDetailsComponent,ComplaintFormComponent];
}

