import { autoinject, bindable } from "aurelia-framework";
import { PLATFORM } from 'aurelia-pal';
import { DialogService } from "aurelia-dialog";

@autoinject
export class ConfirmButton {

  @bindable action = () => { };
  @bindable title = "Confirm";
  @bindable message = "Are you sure";
  @bindable label = "Delete";
  @bindable buttonClass = "btn btn-danger";

  constructor(private dialogService: DialogService) {

  }

  confirm() {
    const settings = {
      viewModel: PLATFORM.moduleName('resources/elements/confirm-dialog'),
      model: {
        message: this.message,
        title: this.title
      },
      lock: true,
      keyboard: true,
      startingZIndex: 10000
    };

    this.dialogService
      .open(settings)
      .whenClosed(response => {
        if (response.wasCancelled || !this.action) {
          return;
        }

        this.action();
      });
  }
}
