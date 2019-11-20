import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './modules/home/components/nav-menu/nav-menu.component';
import { RoutingModule } from './app-routing.module';
import { AuthGuard } from './modules/interceptor/auth/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
		NavMenuComponent,
  ],
  imports: [
    HttpClientModule,
	  BrowserAnimationsModule,
	  BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
	  RoutingModule,
	],
	providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
