import { autoinject, bindable, computedFrom } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { EventAggregator, Subscription } from 'aurelia-event-aggregator';

import { Navigation } from 'models/navigation';

@autoinject()
export class AppSidebarNavLink {
  @bindable navigation: Navigation;
  @bindable isActive: boolean = false;

  completeSubscriber: Subscription;

  constructor(
    private router: Router,
    private eventAggregator: EventAggregator) {

  }

  attached() {
    this.isActive = this.shouldActivate();
    this.completeSubscriber = this.eventAggregator.subscribe('router:navigation:complete', response => {
      this.isActive = this.shouldActivate();
    });
  }

  detached() {
    this.completeSubscriber.dispose();
  }

  shouldActivate(): boolean {
    if (!this.navigation || !this.router.currentInstruction)
      return false;

    let currentUrl = this.router.currentInstruction.fragment;
    return this.navigation.url == currentUrl;
  }
}
