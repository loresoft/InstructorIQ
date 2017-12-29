import { autoinject, bindable } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

import { Authentication } from "services/authentication";

@autoinject
export class NavigationCustomElement {

  @bindable router: Router = null;

  constructor(private authentication: Authentication) {
  }

  logout() {
    this.authentication.logout();
    this.router.navigateToRoute("home");
  }
}
