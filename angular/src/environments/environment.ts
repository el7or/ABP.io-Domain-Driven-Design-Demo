import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'WidgetEngine',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44329/',
    redirectUri: baseUrl,
    clientId: 'WidgetEngine_App',
    responseType: 'code',
    scope: 'offline_access WidgetEngine',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44329',
      rootNamespace: 'Akadimi.WidgetEngine',
    },
  },
} as Environment;
