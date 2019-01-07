import { bindingMode, customAttribute, inject, bindable } from 'aurelia-framework';

@customAttribute('dirty', bindingMode.twoWay)
@inject(Element)
export class DirtyCustomAttribute {
  view = null;
  bindings = null;
  element: Element = null;
  value: boolean = false;
  
  constructor(element: Element) {
    this.element = element;
  }

  created(view) {
    this.view = view;
  }

  bind() {
    // find all two-way bindings to elements within the element that has the 'dirty' attribute.
    this.bindings = this.view.bindings
      .filter(b => b.mode === bindingMode.twoWay && this.element.contains(b.target));

    // intercept each binding's updateSource method.
    let i = this.bindings.length;
    let self = this;
    while (i--) {
      let binding = this.bindings[i];
      binding.dirtyTrackedUpdateSource = binding.updateSource;
      binding.updateSource = function (newValue) {
        this.dirtyTrackedUpdateSource(newValue);
        if (!self.value) {
          self.value = true;
        }
      };
    }
  }

  unbind() {
    // disconnect the dirty tracking from each binding's updateSource method.
    let i = this.bindings.length;
    while (i--) {
      let binding = this.bindings[i];
      binding.updateSource = binding.dirtyTrackedUpdateSource;
      binding.dirtyTrackedUpdateSource = null;
    }
  }
}
