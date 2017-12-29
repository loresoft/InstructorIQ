import { Aurelia } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

import { AuthenticateStep } from 'services/authenticateStep';

export class App {
  public router: Router;

  public configureRouter(config: RouterConfiguration, router: Router) {

    this.router = router;
    
    config.title = 'InstructorIQ';
    config.options.pushState = true;
    config.addAuthorizeStep(AuthenticateStep); 
    
    config.map([
      {
        route: ['', 'Home'],
        name: 'home',
        moduleId: PLATFORM.moduleName('views/home'),
        nav: true,
        title: 'Home'
      },
      // user account
      {
        route: 'login',
        name: 'login',
        moduleId: PLATFORM.moduleName('views/account/login'),
        nav: false,
        title: 'Login'
      },
      {
        route: 'register',
        name: 'register',
        moduleId: PLATFORM.moduleName('views/account/register'),
        nav: false,
        title: 'Register'
      },
      {
        route: 'forgot-password',
        name: 'forgotPassword',
        moduleId: PLATFORM.moduleName('views/account/forgot-password'),
        nav: false,
        title: 'Forgot Password'
      },
      {
        route: 'reset-password/:token',
        name: 'resetPassword',
        moduleId: PLATFORM.moduleName('views/account/reset-password'),
        nav: false,
        title: 'Reset Password'
      },

      // main menu
      {
        route: 'topics',
        name: 'topics',
        moduleId: PLATFORM.moduleName('views/topic/topic-list'),
        nav: true,
        title: 'Topics',
        settings: {
          authorize: true
        }
      },
      {
        route: 'topic/:id',
        name: 'topicEdit',
        moduleId: PLATFORM.moduleName('views/topic/topic-edit'),
        nav: false,
        title: 'Topic Edit',
        settings: {
          authorize: true
        }
      },
      {
        route: 'calendar',
        name: 'calendar',
        moduleId: PLATFORM.moduleName('views/calendar/calendar'),
        nav: true,
        title: 'Calendar'
      },

      // user menu
      {
        route: 'user/profile',
        name: 'profile',
        moduleId: PLATFORM.moduleName('views/user/profile'),
        nav: true,
        title: 'Profile',
        settings: {
          authorize: true
        }
      },

    ]);
  }
}
