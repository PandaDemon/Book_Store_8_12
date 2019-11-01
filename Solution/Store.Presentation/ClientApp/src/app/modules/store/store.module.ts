import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Ng5SliderModule } from 'ng5-slider';

import { StoreComponent } from '../store/components/store/store.component';
import { ProductService } from '../store/services/product.service';
import { StoreRoutingModule } from './store-routing.modules';

@NgModule({
	declarations: [
		StoreComponent
	],
	imports: [
		StoreRoutingModule,
		CommonModule,
		Ng5SliderModule,
	],
	providers: [ProductService]
})
export class StoreModule { }
