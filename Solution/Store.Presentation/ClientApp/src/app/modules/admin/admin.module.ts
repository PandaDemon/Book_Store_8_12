import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.modules';
import { AdminComponent } from './admin.component';
import { AdminSidebarComponent } from './components/admin-sidebar/admin-sidebar.component';
import { PrintingEditionComponent } from './components/printingEdition/printingEdition.component';
import { Ng5SliderModule } from 'ng5-slider';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AdminServise } from './services/admin.service';
import { UsersComponent } from './components/user/user.component';
import { AuthorsComponent } from './components/author/author.component';
import { ModalComponent } from './components/printingEdition/modal/modal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
	declarations: [
		AdminComponent,
		PrintingEditionComponent,
		AdminSidebarComponent,
		UsersComponent,
		AuthorsComponent,
		ModalComponent,
	],
	imports: [
		NgbModule.forRoot(),
		HttpClientModule,
		AdminRoutingModule,
		CommonModule,
		Ng5SliderModule,
		FormsModule,
		ReactiveFormsModule
	],
	providers: [
		AdminServise]
})
export class AdminModule { }
