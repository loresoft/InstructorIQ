import { autoinject, bindable } from 'aurelia-framework';
import { AppRouter } from "aurelia-router";
import { ValidationRules, ValidationController, ValidationControllerFactory } from "aurelia-validation";
import { AuthenticationService } from "services/authenticationService";
import { Notifier } from "services/notifier";
import { BootstrapRenderer } from 'services/bootstrapRenderer';
import { UserRepository } from 'repositories/userRepository';
import { UserRegister } from 'models/userRegister';

@autoinject
export class Register {
  @bindable loading: boolean;
  @bindable dirty: boolean = false;

  @bindable displayName: string;
  @bindable emailAddress: string;
  @bindable password: string;
  @bindable confirmPassword: string;

  controller: ValidationController;

  constructor(
    private appRouter: AppRouter,
    private authentication: AuthenticationService,
    private notifier: Notifier,
    private controllerFactory: ValidationControllerFactory,
    private userRepository: UserRepository
  ) {
    this.controller = controllerFactory.createForCurrentScope();
    this.controller.addRenderer(new BootstrapRenderer());

    this.configureValidation();
  }

  configureValidation() {
    ValidationRules
      .ensure((m: Register) => m.displayName)
      .displayName("Display Name")
      .required()
      .ensure((m: Register) => m.emailAddress)
      .displayName("Email Address")
      .required()
      .email()
      .ensure((m: Register) => m.password)
      .displayName("Password")
      .required()
      .minLength(8)
      .ensure((m: Register) => m.confirmPassword)
      .displayName("Confirm Password")
      .required()
      .satisfies((value: string, object?: Register) => object.password === value)
      .withMessage("Password and Confirm Password do not match.")
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
      var registration: UserRegister = {
        displayName: this.displayName,
        emailAddress: this.emailAddress,
        password: this.password
      }

      // create user then login
      var user = await this.userRepository.register(registration);
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
