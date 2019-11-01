import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";

import { AboutUsComponent } from '../home/components/about-us/about-us.component';
import { HomeComponent } from "./components/home/home.component";


const routes: Routes = [
	{
		path: 'home',
		component: HomeComponent
	},
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
