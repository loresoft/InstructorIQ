import * as nprogress from 'nprogress';

export class Home {
  message = 'Hello World!';

  constructor() {

  }

  showProgress() {
    nprogress.start();
  }

  hideProgress(newValue: boolean) {
    nprogress.done();
  }
}
