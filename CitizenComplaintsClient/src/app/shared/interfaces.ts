export interface ICitizen{
    citizenId:string;
    titleId?:number;
    title?:ICitizenTitle;
    firstName:string;
    middleInitial?:string;
    lastName:string;
    address:string;
    address2:string;
    city:string;
    state:string;
    zipCode:string;
    phoneDay:string;
    phoneEvening?:string;
    phoneFax?:string;
    email?:string;
    createdDateTime?:Date;   
    updatedDateTime?:Date;
    enabled:boolean;
}
export interface ICitizenTitle{
    citizenTitleId:number;
    dsplayName:string;
}

export interface IComplaint{
    complaintId:string;
    statusId:number;
    citizenId:string;
    issueTypeId:number;

    createdDateTime:Date;
    updatedDateTime:Date;
    enabled:boolean;

    citizen?:ICitizen;
    description:IComplaintDescription;
}
export interface IComplaintDescription{
    complaintId:string;
    description:string;
}

export interface IComplaintStatus{
    complaintStatusId:SVGAnimatedNumberList;
    displayName:string;
}

export interface IIssueType{
    issueTypeId:number;
    displayName:string;
}
