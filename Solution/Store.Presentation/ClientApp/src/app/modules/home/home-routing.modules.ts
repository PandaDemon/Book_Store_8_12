import { Routes, RouterModule } from "@angular/router";

import { AboutUsComponent } from '../home/components/about-us/about-us.component';
import { NgModule } from "@angular/core";


const routes: Routes = [
	{
		path: 'about-us',
		component: AboutUsComponent
	}
];

@NgModule({
	imports: [
		RouterModule.forChild(routes),
	],
	exports: [RouterModule]
})
export class HomeRoutingModule { }
