import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observer } from 'rxjs/Observer';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/toPromise';
import {IComplaint, IIssueType} from '../index';

@Injectable()
export class CitizenComplaintsService{
    
    apiUrl = '/api';
    complaints:IComplaint[];
    IssueTypes:IIssueType[];

    constructor(private http: Http) { }

      //local results
    getComplaints():Observable<IComplaint[]>{
        if(!this.complaints){
            return this.getComplaintsAsync();
        }else{
            //todo: i dont think Observable is need here. could use promise instead
            return Observable.create((observer: Observer<any>) => {
                observer.next(this.complaints);
                observer.complete();
            });
        }
    }
  
    getComplaintsAsync():Observable<IComplaint[]>{
         return this.http.get(`${this.apiUrl}/complaints`)
            .map((resp: Response) => this.complaints = resp.json())
            .catch(this.handleError);
    }
  
  
  
    //server results 
    getComplaintAsync(complaintId:string): Promise<IComplaint>{
            return this.http.get(`${this.apiUrl}/complaints/${complaintId}`)
            .map((resp: Response) =>  resp.json().value)
            .catch(this.handleError)
            .toPromise();   
    }
    //Todo: add returned value to local list index 0
    addComplaintAsync(complaint:IComplaint):Promise<boolean>{
        return this.http.put(`${this.apiUrl}/complaints`,complaint)
            .map((resp: Response) =>  {
                    //resp.json().value
                    //add returned complaint to complaints array
                    return true;
            })
            .catch(this.handleError)
            .toPromise();
    }


    
    getLookups():Promise<boolean>{
        if(!this.IssueTypes){
            return this.getLookupsAsync();
        }else{
            return  Promise.resolve(true);
        }        
    }
    getLookupsAsync():Promise<boolean>{
         return this.http.get(`${this.apiUrl}/lookups`)
            .map((resp: Response) =>  {
                let _lookups = resp.json();
                this.IssueTypes = _lookups.issueTypes;
                return true;
            })
            .catch(this.handleError)
            .toPromise();
    }


    private handleError(error: any) {
        let message = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        //Todo: display error and log
        console.error(message); 
        return Observable.throw(message);
    }

}