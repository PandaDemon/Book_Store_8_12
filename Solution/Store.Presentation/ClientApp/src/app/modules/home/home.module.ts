import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AboutUsComponent } from '../home/components/about-us/about-us.component';
import { HomeComponent } from '../home/components/home/home.component';
import { NavMenuComponent } from '../home/components/nav-menu/nav-menu.component';
import { HomeRoutingModule } from './home-routing.modules';

@NgModule({
	imports: [
		HomeRoutingModule,
		CommonModule
	],
	declarations: [
		FormsModule,
		ReactiveFormsModule,
		AboutUsComponent,
		HomeComponent,
		NavMenuComponent
	]
})
export class HomeModule { }
