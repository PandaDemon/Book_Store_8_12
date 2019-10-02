import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './about.component';
import { IndexComponent } from './index.component';
import { SignInComponent } from './signin.component';
import { RegistrationComponent } from './account.module/components/registration/registration.component';
import { ContactComponent } from './contact.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'app.component.html', pathMatch: 'full' },
    { path: 'home', component: IndexComponent, data: { title: 'Home' } },
    { path: 'about', component: AboutComponent, data: { title: 'About' } },
    { path: 'signin', component: SignInComponent, data: { title: 'SignIn' } },
    { path: 'registration', component: RegistrationComponent, data: { title: 'Registration' } },
    { path: 'contact', component: ContactComponent, data: { title: 'Contact' } },
];

export const routing = RouterModule.forRoot(appRoutes);

export const routedComponents = [AboutComponent, IndexComponent, SignInComponent, RegistrationComponent, ContactComponent];