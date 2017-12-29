import * as toastr from 'toastr/toastr';
import { logger } from "services/logger";

export class Notifier {
  constructor(){
    toastr.options = {
      "closeButton": true,
      "progressBar": true,
      "positionClass": "toast-top-right",
    }
  }

  success(message: string, title?: string, options?: any) {
    logger.debug(message);
    toastr.success(message, title, options);
  }

  info(message: string, title?: string, options?: any) {
    logger.info(message);
    toastr.info(message, title, options);
  }

  warning(message: string, title?: string, options?: any) {
    logger.warn(message);
    toastr.warning(message, title, options);
  }

  error(message: string, title?: string, options?: any) {
    logger.error(message);
    toastr.error(message, title, options);
  }

  remove(){
    toastr.remove();
  }
  
  clear(){
    toastr.clear();
  }
}
