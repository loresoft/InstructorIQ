import { autoinject, bindable } from 'aurelia-framework';
import { Router } from 'aurelia-router';
import { EventAggregator, Subscription } from 'aurelia-event-aggregator';

import { Navigation } from 'models/navigation';

@autoinject()
export class AppSidebarNavDropdown {
  @bindable navigation: Navigation;
  @bindable isOpen: boolean = false;

  completeSubscriber: Subscription;
  dropdown: Element;


  constructor(
    private router: Router,
    private eventAggregator: EventAggregator) {

  }

  attached() {
    this.isOpen = this.shouldOpen();
    this.completeSubscriber = this.eventAggregator.subscribe('router:navigation:complete', response => {
      this.isOpen = this.shouldOpen();
    });
  }

  detached() {
    this.completeSubscriber.dispose();
  }

  activate(data) {
    this.navigation = data || {};
  }

  toggle(e: Event) {
    e.preventDefault();
    this.dropdown.classList.toggle("open");
  }

  shouldOpen(): boolean {
    if (!this.navigation || !this.router.currentInstruction) {
      return false;
    }

    let found = false;
    let currentUrl = this.router.currentInstruction.fragment;
    this.navigation.children.forEach(n => {
      if (n.url == currentUrl)
        found = true;
    })

    return found;
  }

}
