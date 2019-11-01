import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.modules';
import { AdminComponent } from './admin.component';
import { AdminSidebarComponent } from './components/admin-sidebar/admin-sidebar.component';
import { PrintingEditionComponent } from './components/printingEdition/printingEdition.component';
import { Ng5SliderModule } from 'ng5-slider';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
	declarations: [
		AdminComponent,
		PrintingEditionComponent,
		AdminSidebarComponent
	],
	imports: [
		HttpClientModule,
		AdminRoutingModule,
		CommonModule,
		Ng5SliderModule,
	]
})
export class AdminModule { }
