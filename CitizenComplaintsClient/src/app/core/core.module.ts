import { NgModule, Optional, SkipSelf } from '@angular/core';
import { HttpModule, Request, XSRFStrategy, CookieXSRFStrategy } from '@angular/http';

import { ComplaintsService } from './complaints.service';

@NgModule({
  imports: [ HttpModule ],
  providers: [ ComplaintsService ]
})
export class CoreModule{

 // @Optional - Optional, injector will provide a null value if not found
 // @SkipSelf - Specifies that the dependency resolution should start from the parent injector. 
  constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
      
      if (parentModule) {
        throw new Error(`${parentModule.constructor.name}  already loaded.`);
      }
  }  

}
