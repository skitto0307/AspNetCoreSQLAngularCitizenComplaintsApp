import { AbstractControl } from '@angular/forms';

//could be part of core
function isNullOrEmpty(value:string){
     return value === undefined || value === null || value === '';
}

export  function emailValidator(control: AbstractControl) {
        
        //return if null or an empty string. allow other validators to validate length or required etc.
        if(isNullOrEmpty(control.value)){
            return null;
        }

        return control.value.match(/^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/)
        ? null:{ 'invalidEmailAddress': true } 
          
}
export function numberOnlyValidator(control:AbstractControl){
    if(isNullOrEmpty(control.value)){
            return null;
    }
    return control.value.match(/^\d+$/)? null:{'invalidNotANumber':true};
}
export function phoneNumberValidator(control:AbstractControl){
    if(isNullOrEmpty(control.value)){
            return null;
    }
    ///todo: storing 20 chars.. will need to validate against 10 digits for phone  and up to 10 for ext
    return control.value.match(/^\d{10}$/)? null:{'invalidPhoneNumber':true};
}