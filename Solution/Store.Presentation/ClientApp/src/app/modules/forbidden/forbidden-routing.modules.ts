import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { ForbiddenComponent } from "./components/forbidden.component";



const routes: Routes = [

	{
		path: 'forbidden',
		component: ForbiddenComponent
	}
];

@NgModule({
	imports: [
		RouterModule.forChild(routes),
	],
	exports: [RouterModule]
})
export class ForbiddenRoutingModule { }
