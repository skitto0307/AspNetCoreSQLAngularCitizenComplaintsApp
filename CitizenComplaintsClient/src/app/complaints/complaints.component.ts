import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ComplaintsService } from '../core/complaints.service';
import {IComplaint} from '../shared'

@Component({
    selector:'complaints',
    templateUrl:'./complaints.component.html',
    styleUrls:['complaints.component.css']
})
export class ComplaintsComponent implements OnInit{
    
    complaints:IComplaint[] = [];

    constructor(private router: Router,
                private service: ComplaintsService){}
    
    ngOnInit() {
         //? pull from local resourse if exist
         //Todo: add refrest button
         this.service.getComplaintsAsync()
            .subscribe(data=> this.complaints = data);
    }
yield
    onSelect(complaint:IComplaint):void{
        //todo: nav to add/complaintId
        this.router.navigate([`/details/${complaint.complaintId}`]);
    }

    onAdd():void{
          this.router.navigate(['/add']);
    }

}