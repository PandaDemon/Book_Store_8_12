import { NgModule } from '@angular/core';

import { ForbiddenRoutingModule } from './forbidden-routing.modules';
import { ForbiddenComponent } from './components/forbidden.component';

@NgModule({
	declarations: [
		ForbiddenComponent
	],
	imports: [
		ForbiddenRoutingModule,
	]
})
export class ForbiddenModule { }
