import { RouterConfiguration, Router } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

export class Profile {
  private router: Router;

  configureRouter(config: RouterConfiguration, router: Router) {
    config.map([
      {
        route: ['profile', ''],
        name: 'userProfile',
        moduleId: PLATFORM.moduleName('./profile-form'),
        nav: true,
        title: 'Profile',
        settings: {
          authorize: true
        }
      },
      {
        route: 'password',
        name: 'userPassword',
        moduleId: PLATFORM.moduleName('./password-form'),
        nav: true,
        title: 'Password',
        settings: {
          authorize: true
        }
      }
    ]);

    this.router = router;
  }
}
