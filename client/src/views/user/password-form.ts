import { autoinject, bindable } from 'aurelia-framework';
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";
import { BootstrapRenderer } from 'services/bootstrapRenderer';
import { UserRepository } from 'repositories/userRepository';
import { AuthenticationService } from 'services/authenticationService';
import { AlertMessage } from 'models/alertMessage';
import { Notifier } from 'services/notifier';

@autoinject
export class PasswordForm {
  @bindable loading: boolean = false;
  @bindable dirty: boolean = false;

  @bindable currentPassword: string;
  @bindable newPassword: string;
  @bindable confirmPassword: string;

  controller: ValidationController;

  constructor(
    private notifier: Notifier,
    private controllerFactory: ValidationControllerFactory,
    private authentication: AuthenticationService,
    private userRepository: UserRepository
  ) {
    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapRenderer());

    this.configureValidation();
  }

  configureValidation() {
    ValidationRules
      .ensure((m: PasswordForm) => m.currentPassword)
      .displayName("Current Password")
      .required()
      .ensure((m: PasswordForm) => m.newPassword)
      .displayName("New Password")
      .required()
      .minLength(8)
      .ensure((m: PasswordForm) => m.confirmPassword)
      .displayName("Confirm Password")
      .required()
      .satisfies((value: string, object?: PasswordForm) => object.newPassword === value)
      .withMessage("New Password and Confirm Password do not match.")
      .on(this);
  }

  resetForm(){
    this.currentPassword = '';
    this.newPassword = '';
    this.confirmPassword = '';
    this.dirty = false;
    this.controller.reset();
  }

  async saveForm() {
    let v = await this.controller.validate();
    if (!v.valid) {
      this.notifier.error("Please ensure all fields are filled out.");
      return;
    }

    this.loading = true;
    try {
      await this.userRepository.changePassword(this.authentication.userId, this.currentPassword, this.newPassword);
      this.notifier.success("Password changed successfully");
      this.resetForm();
    } catch (e) {
      await this.notifier.error(e);
    } finally {
      this.loading = false;
    }
  }
}
