import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './modules/home/components/home/home.component';



const appRoutes: Routes = [
	{
		path: '',
		component: HomeComponent
	},
	{
		path : 'about-us',
		loadChildren: () => import('./modules/home/components/about-us/about-us.component').then(module => module.AboutUsComponent)
	},
	{
		path : 'account',
		loadChildren : () => import('./modules/account/account.module').then(module => module.AccountModule)
	},
	{
		path : 'store',
		loadChildren: () => import('./modules/store/components/store/store.component').then(module => module.StoreComponent)
	},
	{ path : '**', redirectTo: '/', pathMatch: 'full' }
]; 

@NgModule({
	imports: [RouterModule.forRoot(appRoutes)],
	exports: [RouterModule]
})

export class RoutingModule { }
