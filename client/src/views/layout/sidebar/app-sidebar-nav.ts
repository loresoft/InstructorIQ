import { autoinject } from 'aurelia-framework';

import { SidebarNavigation } from 'services/sidebarNavigation';

@autoinject()
export class AppSidebarNav {    
  
  constructor(private sidebarNavigation: SidebarNavigation) {
  }
}
