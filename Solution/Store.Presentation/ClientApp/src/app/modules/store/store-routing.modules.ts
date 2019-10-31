import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";

import { StoreComponent } from '../store/components/store/store.component';


const routes: Routes = [
	{
		path: 'store',
		component: StoreComponent
	}
];

@NgModule({
	imports: [
		RouterModule.forChild(routes),
	],
	exports: [RouterModule]
})
export class StoreRoutingModule { }
