/// <reference types="aurelia-loader-webpack/src/webpack-hot-interface"/>

import 'font-awesome/scss/font-awesome.scss';
import './scss/style.scss';

import 'isomorphic-fetch';

import { Aurelia } from 'aurelia-framework';
import environment from './environment';
import { PLATFORM } from 'aurelia-pal';
import * as Bluebird from 'bluebird';

import { LogManager } from "aurelia-framework";
import { ConsoleAppender } from "aurelia-logging-console";


// remove out if you don't want a Promise polyfill (remove also from webpack.config.js)
Bluebird.config({ warnings: { wForgottenReturn: false } });

export async function configure(aurelia: Aurelia) {
  aurelia.use
    .standardConfiguration()
    .developmentLogging()
    .plugin(PLATFORM.moduleName('aurelia-configuration'), c => {
      c.setDirectory('./');
      c.setConfig('application.json');
    })
    .plugin(PLATFORM.moduleName('aurelia-dialog'))
    .plugin(PLATFORM.moduleName('aurelia-validation'))
    .feature(PLATFORM.moduleName('resources/index'));

  await aurelia.start();
  await aurelia.setRoot(PLATFORM.moduleName('app'));
}
