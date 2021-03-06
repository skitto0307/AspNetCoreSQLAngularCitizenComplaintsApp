import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { ComplaintsService } from '../core/complaints.service';
import { IComplaint } from '../shared'

@Component({
    selector:'complaints-details',
    templateUrl:'./complaint-details.component.html',
    styleUrls:['./complaint-details.component.scss']
})
export class ComplaintDetailsComponent implements OnInit{

    complaint:IComplaint;

    constructor(private router: Router, 
              private route: ActivatedRoute, 
              private service: ComplaintsService){ }

    ngOnInit(): void {
        //no need to subscribe to router params here. route will not change while active
        let _complaintId = this.route.snapshot.params["id"];
        this.service.getComplaintAsync(_complaintId)
            .then((data)=> {
                this.complaint = data
                //console.log(this.complaint);
            });   
        
    }


    onClose(): void{
             this.router.navigate(['/complaints']);
    }
    
    onRrefresh():void{}
}