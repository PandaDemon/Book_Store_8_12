import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './modules/home/components/nav-menu/nav-menu.component';
import { HomeComponent } from './modules/home/components/home/home.component';
import { AboutUsComponent } from './modules/home/components/about-us/about-us.component';

import { StoreComponent } from './modules/store/components/store/store.component';

import { LoginComponent } from './modules/account/components/login/login.component';
import { RegistrationComponent } from './modules/account/components/registration/registration.component';

import { PrintingEditionComponent } from './modules/admin/components/printingedition/printingedition.component';

import { ProductService } from './modules/store/services/product.service';
import { AccountService } from './modules/account/services/account.service';

import { Ng5SliderModule } from 'ng5-slider';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutUsComponent,
    LoginComponent,
    RegistrationComponent,
    StoreComponent,
    PrintingEditionComponent
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
  providers: [ProductService, AccountService],
  bootstrap: [AppComponent]
})
export class AppModule { }
