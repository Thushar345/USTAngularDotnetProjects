import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideToastr } from 'ngx-toastr';  

bootstrapApplication(AppComponent, {
  providers: [
    provideToastr({ 
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
    }),
  ],
}).catch((err) => console.error(err));
