import { FrameworkConfiguration } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';

export function configure(config: FrameworkConfiguration) {
  config.globalResources([  
    PLATFORM.moduleName('resources/attributes/loading-state'),
    PLATFORM.moduleName('resources/attributes/dirty'),

    PLATFORM.moduleName('resources/elements/alert'),
    PLATFORM.moduleName('resources/elements/busy-button'),
    PLATFORM.moduleName('resources/elements/loading-indicator'),
    PLATFORM.moduleName('resources/elements/gravatar'),
    PLATFORM.moduleName('resources/elements/pagination'),

    PLATFORM.moduleName('resources/value-converters/dateFormat'),

  ]);
}
