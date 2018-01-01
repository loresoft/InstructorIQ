import { autoinject, bindable } from 'aurelia-framework';
import { AureliaConfiguration } from "aurelia-configuration";

@autoinject
export class FooterCustomElement{
  @bindable year: number = new Date().getFullYear();
  @bindable version: string = "1.0.0.0";

  constructor(private configuration: AureliaConfiguration){
    this.version = configuration.get("Version", "1.0.0.0");
  }
}
