import { autoinject, bindable } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

import { AuthenticationService } from "services/authenticationService";

@autoinject
export class NavigationCustomElement {

  @bindable router: Router = null;

  constructor(private authentication: AuthenticationService) {
  }

  logout() {
    this.authentication.logout();
    this.router.navigateToRoute("home");
  }
}
