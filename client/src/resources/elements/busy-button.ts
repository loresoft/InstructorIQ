import { bindable } from "aurelia-framework";

export class BusyButton {
  @bindable id: string = 'submit-button'
  @bindable busy: boolean = false;
  @bindable disabled: boolean = false;
  @bindable type: string = 'submit';
  @bindable class: string = 'btn btn-primary';
  @bindable label: string = 'Submit';
  @bindable busyLabel: string = 'Loading...';

  constructor() {
  }
}
