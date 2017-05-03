import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
// import {isPresent} from '@angular/core/src/facade/lang';

import { ComplaintsService } from '../core/complaints.service';
import {
        IComplaint,IIssueType,
        emailValidator,numberOnlyValidator,phoneNumberValidator,  
        NewGuid} from '../shared'


//todo: Use data Model to build Formgroups 
//todo: Break formbuilder groups down into smaller  methods
//Todo: Create us states table and fetch with lookups.
//Todo: Add saving indicator. 
//Todo: complaintId should be passed  as a param to formgrup method

@Component({
    selector:'complaint-from',
    templateUrl:'./complaint-form.component.html',
    styleUrls:['complaint-form.component.scss']
})
export class ComplaintFormComponent implements OnInit{
    
   form: FormGroup;
    locationAddresses:FormArray;
   
    complaintId:string;
    isActive:boolean = false;
    issueTypes:IIssueType[] = [];

    constructor(private router: Router,
                public formBuilder: FormBuilder, 
                private service:ComplaintsService) {}

    ngOnInit() {
 
        this.service.getLookups()
            .then((data)=> {
                this.issueTypes = this.service.IssueTypes;        
                this.buildForm();
                this.isActive = true;
            });
    }
    onSubmit():void{
        if(this.form.valid){
          this.service.addComplaintAsync(this.form.value)
            .then(data=>  this.router.navigate(['/complaints']));
        }   
    }
    onAddressAdd():void{
        //this.locationAddresses.splice(0, 0, this.buildLocationGroup());
        this.locationAddresses.insert(0, this.buildLocationGroup());
        //this.locationAddresses.push(this.buildLocationGroup());
    }
    onCancel(event){
        
        //hack - app refreshes due to button being inside the form. 
        event.preventDefault();
        event.stopPropagation();

        this.router.navigate(['/']);
    }

    getFormInfo(){
        console.log(this.form);
    }

        //todo: wrap in promise
    private buildForm():void{
                let _complaintId:string = NewGuid();
        this.complaintId = _complaintId;
        let _citizenId:string = NewGuid();

        this.form = this.formBuilder.group({
            complaintId:_complaintId,
            citizenId:_citizenId,
            citizen: this.formBuilder.group({
                citizenId:_citizenId,
                firstName:['', Validators.required],
                middleInitial:null,
                lastName:['', Validators.required],
                address:['', Validators.required],
                address2:null,
                city:['Duckburg', Validators.required],
                stateId:['CA',[Validators.required, Validators.minLength(2)]], 
                zipCode:[null,[Validators.required,Validators.minLength(5)]],
                phoneDay:['',[Validators.required,phoneNumberValidator]],
                phoneEvening:[null,[phoneNumberValidator]],
                phoneFax:[null,[phoneNumberValidator]],  
                email:[null, [emailValidator]]    
            }),
            description: this.formBuilder.group({
                complaintId:_complaintId,
                description: [null, Validators.required] 
            }),
            locationAddresses: this.buildLocationArray(),
            issueTypeId:[null, Validators.required] 
        });
       
    }
    private buildLocationArray():FormArray{
        this.locationAddresses = this.formBuilder.array([
            this.buildLocationGroup()
        ]);
        return this.locationAddresses;
    }
    private buildLocationGroup():FormGroup{
       return this.formBuilder.group({
           locationAddressId: NewGuid(),
           complaintId: this.complaintId,
           address:[null,Validators.required],
           address2:null,
           city:['Duckburg',Validators.required],
           stateId:['CA',[Validators.required,Validators.minLength(2)]],
           zipCode:[null,Validators.minLength(5)]
       });
    }
}