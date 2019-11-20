import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AboutUsComponent } from '../home/components/about-us/about-us.component';
import { HomeComponent } from '../home/components/home/home.component';
import { HomeRoutingModule } from './home-routing.modules';

@NgModule({
	declarations: [
		AboutUsComponent,
		HomeComponent
	],
	imports: [
		HomeRoutingModule,
		CommonModule,
    FormsModule,
		ReactiveFormsModule,
	]
})
export class HomeModule { }
