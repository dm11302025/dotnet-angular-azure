import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';
import { Demo } from './app/demo/demo';

bootstrapApplication(App, appConfig)
  .catch((err) => console.error(err));
