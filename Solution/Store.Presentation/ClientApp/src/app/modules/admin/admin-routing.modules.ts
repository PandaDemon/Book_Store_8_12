import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";

import { AdminComponent } from "./admin.component";
import { PrintingEditionComponent } from "./components/printingEdition/printingEdition.component";
import { UsersComponent } from "./components/user/user.component";
import { AuthorsComponent } from "./components/author/author.component";


const routes: Routes = [
	{
		path: '',
		component: AdminComponent,
		children: [{
			path: 'editions',
			component: PrintingEditionComponent
		},
		{
			path: 'users',
			component: UsersComponent
		},
		{
			path: 'authors',
			component: AuthorsComponent
		}]
	}
];

@NgModule({
	imports: [
		RouterModule.forChild(routes),
	],
	exports: [RouterModule]
})
export class AdminRoutingModule { }
