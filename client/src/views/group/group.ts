import { autoinject, bindable } from 'aurelia-framework';

@autoinject    
export class Group {    
  @bindable message: string;
  
  constructor() {
    this.message = 'Hello world';
  }
}