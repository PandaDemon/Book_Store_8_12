import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
	{
		path: '',
		redirectTo: '/',
		pathMatch: 'full'
	},
	{
		path: 'home',
		loadChildren: () => import('./modules/home/home.module').then(module => module.HomeModule)
	},
	{
		path : 'account',
		loadChildren : () => import('./modules/account/account.module').then(module => module.AccountModule)
	},
	{
		path: 'store',
		loadChildren: () => import('./modules/store/store.module').then(module => module.StoreModule)
	},
	{
		path: 'admin',
		loadChildren: () => import('./modules/admin/admin.module').then(module => module.AdminModule)
	},
	{ path : '**', redirectTo: '/', pathMatch: 'full' }
]; 

@NgModule({
	imports: [RouterModule.forRoot(appRoutes)],
	exports: [RouterModule]
})

export class RoutingModule { }
