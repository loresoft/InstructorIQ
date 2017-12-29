import { autoinject, bindable } from 'aurelia-framework';
import { AppRouter } from "aurelia-router";
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";

import { Authentication } from "services/authentication";
import { Notifier } from "services/notifier";
import { BootstrapRenderer } from 'services/bootstrapRenderer';


@autoinject
export class Login {

  @bindable message: string;
  @bindable emailAddress: string;
  @bindable password: string;

  @bindable loading: boolean;

  controller: ValidationController;

  constructor(
    private appRouter: AppRouter,
    private authentication: Authentication,
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
    this.message = null;
    
    let v = await this.controller.validate();
    if (!v.valid) {
      this.notifier.error("Please ensure all fields are filled out.", "Validation Failure");
      return;
    } 
    
    this.loading = true;
    try {
      var response = await this.authentication.login(this.emailAddress, this.password);

      if (response.successful) {
        this.appRouter.navigate(this.authentication.initialUrl);
        return;
      }

      this.message = response.message;
      this.notifier.error(response.message, "Login Failure");

    } catch (e) {
      this.notifier.error(e, "Login Error");
    } finally{
      this.loading = false;
    }
  }
}
