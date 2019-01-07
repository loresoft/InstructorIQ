import { bindable, bindingMode } from "aurelia-framework";

export class Alert {    
  @bindable({defaultBindingMode: bindingMode.twoWay}) active: boolean;
  @bindable message: string;
  @bindable type: string// primary, secondary, success, danger, warning, info
  @bindable timeout: number;


  constructor() {
    this.message = 'Hello world';
    this.type = 'info';
    this.active = false;

  }

  close(){
    this.active = false;
  }
}
