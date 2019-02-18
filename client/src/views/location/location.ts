import { autoinject, bindable } from 'aurelia-framework';

@autoinject    
export class Location {    
  @bindable message: string;
  
  constructor() {
    this.message = 'Hello world';
  }
}