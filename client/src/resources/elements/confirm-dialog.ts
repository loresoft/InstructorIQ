import { autoinject, bindable } from "aurelia-framework";
import { DialogController } from 'aurelia-dialog';

@autoinject
export class ConfirmDialog {
  @bindable title = "Confirm";
  @bindable message = "Are you sure?";
  @bindable cancelText = "Cancel";
  @bindable confirmText = "Ok";

  constructor(public controller: DialogController) {

  }

  activate(data: string | any) {
    if (typeof data === 'string') {
      this.message = data;
      return;
    }

    if (data.title) {
      this.title = data.title;
    }
    if (data.message) {
      this.message = data.message;
    }
    if (data.cancelText) {
      this.cancelText = data.cancelText;
    }
    if (data.confirmText) {
      this.confirmText = data.confirmText;
    }
  }
}
