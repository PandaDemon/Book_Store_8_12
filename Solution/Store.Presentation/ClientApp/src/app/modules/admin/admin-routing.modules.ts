import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";

import { AdminComponent } from "./admin.component";
import { PrintingEditionComponent } from "./components/printingEdition/printingEdition.component";


const routes: Routes = [
	{
		path: 'admin',
		component: AdminComponent
	},
	{
		path: 'editions',
		component: PrintingEditionComponent
	}
];

@NgModule({
	imports: [
		RouterModule.forChild(routes),
	],
	exports: [RouterModule]
})
export class AdminRoutingModule { }
