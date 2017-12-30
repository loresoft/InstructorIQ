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
        route: 'groups',
        name: 'groups',
        moduleId: PLATFORM.moduleName('views/group/group-list'),
        nav: true,
        title: 'Groups',
        settings: {
          authorize: true
        }
      },
      {
        route: 'group/:id',
        name: 'groupEdit',
        moduleId: PLATFORM.moduleName('views/group/group-edit'),
        nav: false,
        title: 'Group Edit',
        settings: {
          authorize: true
        }
      },
      {
        route: 'locations',
        name: 'locations',
        moduleId: PLATFORM.moduleName('views/location/location-list'),
        nav: true,
        title: 'Locations',
        settings: {
          authorize: true
        }
      },
      {
        route: 'location/:id',
        name: 'locationEdit',
        moduleId: PLATFORM.moduleName('views/location/location-edit'),
        nav: false,
        title: 'Location Edit',
        settings: {
          authorize: true
        }
      },
      {
        route: 'instructors',
        name: 'instructors',
        moduleId: PLATFORM.moduleName('views/instructor/instructor-list'),
        nav: true,
        title: 'Instructors',
        settings: {
          authorize: true
        }
      },
      {
        route: 'instructor/:id',
        name: 'instructorEdit',
        moduleId: PLATFORM.moduleName('views/instructor/instructor-edit'),
        nav: false,
        title: 'Instructor Edit',
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

      {
        route: 'organization/settings',
        name: 'organizationSettings',
        moduleId: PLATFORM.moduleName('views/organization/settings'),
        nav: true,
        title: 'Settings'
      },
      {
        route: 'organization/membership',
        name: 'organizationMembership',
        moduleId: PLATFORM.moduleName('views/organization/membership'),
        nav: true,
        title: 'Membership'
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
