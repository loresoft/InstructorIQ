import {autoinject, bindable} from 'aurelia-framework';

@autoinject()
export class LoadingStateCustomAttribute {
  
  @bindable loadingText: string = "Loading...";
  @bindable({ primaryProperty: true }) busy: boolean;

  private originalText: string;

  constructor(private element: Element) { 
    
  }

  busyChanged(newValue, oldValue) {
    if (newValue) {      
      this.originalText = this.getElementValue();
      this.setElementValue(this.loadingText, newValue);
    } else {
      this.setElementValue(this.originalText, newValue);
    }
  }

  getElementValue(): string{
    if (this.element instanceof HTMLInputElement){
      let input = <HTMLInputElement>this.element;
      return input.value;
    } 

    if (this.element instanceof HTMLButtonElement) {
      let button = <HTMLButtonElement>this.element;
      return button.innerHTML;
    } 
    
    return this.element.innerHTML;
  }

  setElementValue(value: string, disabled: boolean): void{
    if (this.element instanceof HTMLInputElement){
      let input = <HTMLInputElement>this.element;
      input.value = value;
      input.disabled = disabled;
      return;
    } 
    
    if (this.element instanceof HTMLButtonElement) {
      let button = <HTMLButtonElement>this.element;
      button.innerHTML = value;
      button.disabled = disabled;
      return;
    } 
    
    this.element.innerHTML = value;
  }
}

