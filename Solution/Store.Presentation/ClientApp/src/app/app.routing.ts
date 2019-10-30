import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './modules/home/components/home/home.component';
import { AboutUsComponent } from './modules/home/components/about-us/about-us.component';
import { StoreComponent } from './modules/store/components/store/store.component';
import { LoginComponent } from './modules/account/components/login/login.component';
import { RegistrationComponent } from './modules/account/components/registration/registration.component';


const routes: Routes = [
	{ path: '', component: HomeComponent, pathMatch: 'full' },
	{ path: 'about-us', component: AboutUsComponent },
	{ path: 'login', component: LoginComponent },
	{ path: 'registration', component: RegistrationComponent },
	{ path: 'store', component: StoreComponent },
];
