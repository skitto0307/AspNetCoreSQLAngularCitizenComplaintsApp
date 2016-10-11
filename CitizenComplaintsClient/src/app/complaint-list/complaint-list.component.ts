import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import {CitizenComplaintsService, IComplaint} from '../shared'

@Component({
    selector:'complaint-list',
    templateUrl:'./complaint-list.component.html',
    styleUrls:['complaint-list.component.css']
})
export class ComplaintListComponent implements OnInit{
    
    complaints:IComplaint[] = [];

    constructor(private router: Router,
                private service: CitizenComplaintsService){}
    
    ngOnInit() {
         //? pull from local resourse if exist
         //Todo: add refrest button
         this.service.getComplaintsAsync()
            .subscribe(data=> this.complaints = data);
    }

    onSelect(complaint:IComplaint):void{
        //todo: nav to add/complaintId
        this.router.navigate([`/details/${complaint.complaintId}`]);
    }

    onAdd():void{
          this.router.navigate(['/add']);
    }

}