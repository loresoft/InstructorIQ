import { autoinject, bindable } from 'aurelia-framework';
import { Router } from 'aurelia-router';

import { Navigation } from 'models/navigation';

@autoinject()
export class AppSidebarNavItem {    
  @bindable navigation: Navigation;

  constructor(private router: Router) {

  }

  activate(data) {
    this.navigation = data || {};
  }
}
