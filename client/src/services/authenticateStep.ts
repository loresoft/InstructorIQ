import { autoinject } from 'aurelia-framework';
import { RouterConfiguration, Router, NavigationInstruction, Next, Redirect } from 'aurelia-router';

import { Authentication } from "services/authentication";
import { logger } from "services/logger";

@autoinject
export class AuthenticateStep {
  constructor(
    private authentication: Authentication) {

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
