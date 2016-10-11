import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {ComplaintListComponent} from './complaint-list/complaint-list.component';
import {ComplaintDetailsComponent} from './complaint-details/complaint-details.component';
//Todo: remove details and use form for add and update
import {ComplaintFormComponent} from './complaint-form/complaint-form.component';


const routes: Routes = [
  {path:'', redirectTo:'list', pathMatch:'full'},
  {path:'list', component:ComplaintListComponent},
  {path:'details/:id', component:ComplaintDetailsComponent},
  {path:'add', component:ComplaintFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class CitizenComplaintsClientRoutingModule { }
//import will take single object or array
export const routedComponents = [ComplaintListComponent,ComplaintDetailsComponent,ComplaintFormComponent];
