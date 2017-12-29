import { FrameworkConfiguration } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';

export function configure(config: FrameworkConfiguration) {
  config.globalResources([
    PLATFORM.moduleName('resources/attributes/loading-state'),
    PLATFORM.moduleName('resources/elements/loading-indicator'),
    PLATFORM.moduleName('resources/elements/gravatar')
  ]);
}
