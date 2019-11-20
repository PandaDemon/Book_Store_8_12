import { Component } from '@angular/core';

@Component({
	selector: 'admin-sidebar',
	templateUrl: './admin-sidebar.component.html',
	styleUrls: ['./admin-sidebar.component.scss']
})

export class AdminSidebarComponent {
	isExpanded = false;

	collapse() {
		this.isExpanded = false;
	}

	toggle() {
		this.isExpanded = !this.isExpanded;
	}
}


