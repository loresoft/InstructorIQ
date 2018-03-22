import { autoinject } from 'aurelia-framework';

@autoinject()
export class AppBodyTogglerCustomAttribute {
  _toggleOpen: any;
  value: string;

  constructor(private element: Element) { 
    this._toggleOpen = this.toggleOpen.bind(this);
  }

  attached() {
    this.element.addEventListener('click', this._toggleOpen);    
  }

  detached() {
    this.element.removeEventListener('click', this._toggleOpen);    
  }

  toggleOpen(e: Event) {
    e.preventDefault();
    document.querySelector('body').classList.toggle(this.value);
  }

}

