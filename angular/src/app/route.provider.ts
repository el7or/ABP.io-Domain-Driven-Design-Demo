import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/widget-engine',
        name: '::Menu:WidgetEngine',
        iconClass: 'fas fa-object-ungroup',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/books',
        name: '::Menu:Books',
        iconClass: 'fas fa-book',
        parentName: '::Menu:WidgetEngine',
        layout: eLayoutType.application,
        requiredPolicy: 'WidgetEngine.Books',
      },
      {
        path: '/authors',
        name: '::Menu:Authors',
        iconClass: 'fas fa-user',
        parentName: '::Menu:WidgetEngine',
        layout: eLayoutType.application,
        requiredPolicy: 'WidgetEngine.Authors',
      },
      {
        path: '/tags',
        name: '::Menu:Tags',
        iconClass: 'fas fa-tag',
        parentName: '::Menu:WidgetEngine',
        layout: eLayoutType.application,
        requiredPolicy: 'WidgetEngine.Tags',
      },
    ]);
  };
}

