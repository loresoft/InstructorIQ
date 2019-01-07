import { autoinject } from 'aurelia-framework';
import { RouterConfiguration, Router, NavigationInstruction, Next, Redirect } from 'aurelia-router';

import { AuthenticationService } from "services/authenticationService";
import { logger } from "services/logger";

@autoinject
export class AuthenticateStep {
  constructor(
    private authentication: AuthenticationService) {

  }

  async run(navigationInstruction: NavigationInstruction, next: Next): Promise<any> {
    let isLoggedIn = await this.authentication.checkToken();
    let currentRoute = navigationInstruction.config;
    let loginRequired = navigationInstruction
      .getAllInstructions()
      .some(i => i.config.settings.authorize === true);

    if (isLoggedIn === false && loginRequired === true) {
      logger.warn("AuthorizeStep access denied", currentRoute)
      this.authentication.initialUrl = navigationInstruction.fragment;
      return next.cancel(new Redirect('login'));
    }

    return next();
  }
}
