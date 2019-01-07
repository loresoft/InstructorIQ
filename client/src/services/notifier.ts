import { json } from 'aurelia-fetch-client';
import { logger } from "services/logger";
import { AlertMessage } from 'models/alertMessage';
import { transient, bindable } from 'aurelia-framework';

@transient()
export class Notifier {
  @bindable alert: AlertMessage;

  constructor() {
    this.alert = {
      type: 'info',
      message: '',
      active: false
    }
  }

  success(message: string) {
    logger.debug(message);

    this.alert.message = message;
    this.alert.type = 'success';
    this.alert.active = true;
  }

  info(message: string) {
    logger.info(message);

    this.alert.message = message;
    this.alert.type = 'info';
    this.alert.active = true;
  }

  warning(message: string) {
    logger.warn(message);

    this.alert.message = message;
    this.alert.type = 'warning';
    this.alert.active = true;
  }

  async error(message: any) {
    const m = await this.format(message);

    logger.error(m);

    this.alert.message = m;
    this.alert.type = 'danger';
    this.alert.active = true;
  }

  clear() {
    this.alert.active = false;
  }

  async format(result: any): Promise<string> {
    if (typeof result === 'string') {
      return result;
    }

    if (result.body && typeof result.json === 'function') {

      let o: any = {};
      try {
        o = await result.json();
      }
      catch (e) {
        logger.error(e);
      }

      if (o.message) {
        return o.message;
      }

      if (o.error) {
        return o.error;
      }
    }

    if (result.statusText) {
      return result.statusText;
    }

    return result;
  }
}
