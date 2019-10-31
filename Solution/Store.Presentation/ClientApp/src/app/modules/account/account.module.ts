import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { LoginComponent } from '../account/components/login/login.component';
import { RegistrationComponent } from '../account/components/registration/registration.component';
import { AccountService } from '../account/services/account.service';
import { AccountRoutingModule } from './account-routing.modules';

@NgModule({
	declarations: [
		LoginComponent,
		RegistrationComponent
	],
	imports: [
		AccountRoutingModule,
		CommonModule,
		FormsModule,
		ReactiveFormsModule
	],
	providers: [AccountService]
})
export class AccountModule { }
