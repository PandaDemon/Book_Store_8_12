import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './modules/home/components/nav-menu/nav-menu.component';
import { HomeComponent } from './modules/home/components/home/home.component';
import { AboutUsComponent } from './modules/home/components/about-us/about-us.component';
import { StoreComponent } from './modules/store/components/store/store.component';
//import { LoginComponent } from './modules/account/components/login/login.component';
//import { RegistrationComponent } from './modules/account/components/registration/registration.component';
import { PrintingEditionComponent } from './modules/admin/components/printingedition/printingedition.component';
import { ProductService } from './modules/store/services/product.service';

import { Ng5SliderModule } from 'ng5-slider';
import { ToastrModule } from 'ngx-toastr';
import { RoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutUsComponent,
    //LoginComponent,
    //RegistrationComponent,
		StoreComponent,
    PrintingEditionComponent
  ],
  imports: [
    HttpClientModule,
    //FormsModule,
    //ReactiveFormsModule,
	  Ng5SliderModule,
	  BrowserAnimationsModule,
	  BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
	  ToastrModule.forRoot(),
	  RoutingModule,
    //RouterModule.forRoot([
    //  { path: '', component: HomeComponent, pathMatch: 'full' },
    //  { path: 'about-us', component: AboutUsComponent },
    //  { path: 'login', component: LoginComponent },
    //  { path: 'registration', component: RegistrationComponent },
    //  { path: 'store', component: StoreComponent },
    //])
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
