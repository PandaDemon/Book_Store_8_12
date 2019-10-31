import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { StoreComponent } from '../store/components/store/store.component';
import { ProductService } from '../store/services/product.service';
import { StoreRoutingModule } from './store-routing.modules';

@NgModule({
	imports: [
		StoreRoutingModule,
		CommonModule
	],
	declarations: [
		FormsModule,
		ReactiveFormsModule,
		StoreComponent
	],
	providers: [ProductService]
})
export class HomeModule { }
