import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './home.module/components/nav-menu/nav-menu.component';
import { HomeComponent } from './home.module/components/home/home.component';
import { AboutUsComponent } from './home.module/components/about-us/about-us.component';

import { StoreComponent } from './store.module/components/store/store.component';

import { LoginComponent } from './account.module/components/login/login.component';
import { RegistrationComponent } from './account.module/components/registration/registration.component';

import { ProductService } from './store.module/services/product.service';

import { Ng5SliderModule } from 'ng5-slider';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutUsComponent,
    LoginComponent,
    RegistrationComponent,
    StoreComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    Ng5SliderModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'about-us', component: AboutUsComponent },
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
      { path: 'store', component: StoreComponent },
    ])
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
