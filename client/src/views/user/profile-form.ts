import { autoinject, bindable } from 'aurelia-framework';
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";
import { Notifier } from "services/notifier";
import { BootstrapRenderer } from 'services/bootstrapRenderer';
import { AuthenticationService } from 'services/authenticationService';
import { compare } from 'fast-json-patch'
import { UserRepository } from 'repositories/userRepository';

@autoinject
export class ProfileForm { 
  @bindable displayName: string ;
  @bindable emailAddress: string;
  
  @bindable loading: boolean = false;
  @bindable dirty: boolean = false;

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
      .ensure((m: ProfileForm) => m.displayName)
      .displayName("Display Name")
      .required()
      .ensure((m: ProfileForm) => m.emailAddress)
      .displayName("Email Address")
      .required()
      .email()
      .on(this);
  }

  attached() {
    this.loadForm();
  }

  loadForm() {
    this.displayName = this.authentication.name;
    this.emailAddress = this.authentication.email;

    this.dirty = false;
  }

  async saveForm() {
    let v = await this.controller.validate();
    if (!v.valid) {
      this.notifier.error("Please ensure all fields are filled out.");
      return;
    }

    this.loading = true;
    try {
      const original = {
        displayName: this.authentication.name,
        emailAddress: this.authentication.email,
      }
      const profile = {
        displayName: this.displayName,
        emailAddress: this.emailAddress,
      }
      const operations = compare(original, profile);

      await this.userRepository.patchProfile(this.authentication.userId, operations);
      await this.authentication.refreshToken();

      this.notifier.success("Profile updated successfully")

      this.loadForm();
    } catch (e) {
      await this.notifier.error(e);
    } finally {
      this.loading = false;
    }
  }
}
