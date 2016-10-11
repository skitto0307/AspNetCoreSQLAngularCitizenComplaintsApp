import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'phone' })
export class PhonePipe implements PipeTransform {

  transform(value: any) {
	
      if (value) {
        //Todo: create pipe - phone with ext
        let _match = value.match(/^(\d{3})(\d{3})(\d{4})$/);
        value = (!_match) ? null : "(" + _match[1] + ")" + _match[2] + "-" + _match[3];
        return value;
	  }
	  return value;
  }

}