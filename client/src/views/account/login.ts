import { autoinject, bindable } from 'aurelia-framework';
import { AppRouter } from "aurelia-router";
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";

import { AuthenticationService } from "services/authenticationService";
import { Notifier } from "services/notifier";
import { BootstrapRenderer } from 'services/bootstrapRenderer';

@autoinject
export class Login {
  @bindable loading: boolean;
  @bindable dirty: boolean = false;

  @bindable emailAddress: string;
  @bindable password: string;

  controller: ValidationController;

  constructor(
    private appRouter: AppRouter,
    private authentication: AuthenticationService,
    private notifier: Notifier,
    private controllerFactory: ValidationControllerFactory
  ) {
    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapRenderer());

    this.configureValidation();
  }

  configureValidation() {
    ValidationRules
      .ensure((m: Login) => m.emailAddress)
        .displayName("Email Address")
        .required()
        .email()
      .ensure((m: Login) => m.password)
        .displayName("Password")
        .required()
      .on(this);
  }

  async processForm() {   
    let v = await this.controller.validate();
    if (!v.valid) {
      this.notifier.error("Please ensure all fields are filled out.");
      return;
    } 
    
    this.loading = true;
    try {
      var response = await this.authentication.login(this.emailAddress, this.password);

      if (response.successful) {
        this.appRouter.navigate(this.authentication.initialUrl);
        return;
      }

      await this.notifier.error(response.message);

    } catch (e) {
      await this.notifier.error(e);
    } finally{
      this.loading = false;
    }
  }
}
