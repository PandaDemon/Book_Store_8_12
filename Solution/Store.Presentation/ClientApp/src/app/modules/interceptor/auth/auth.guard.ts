import { RouterStateSnapshot, ActivatedRouteSnapshot, CanActivate, Router } from "@angular/router";
import { AccountService } from "../../account/services/account.service";
import { Injectable } from "@angular/core";

@Injectable()

export class AuthGuard implements CanActivate {

	constructor(private router: Router, private service: AccountService) {
	}

	canActivate(
		next: ActivatedRouteSnapshot,
		state: RouterStateSnapshot): boolean {
		if (localStorage.getItem('refreshToken') === null) {
			this.router.navigate(['/account/signin']);
			return false;
		}

		let roles = next.data['permittedRoles'] as Array<string>;

		if (roles && !this.service.roleMatch(roles)) {
			this.router.navigate(['/forbidden']);
			return false;
		}

		return true;
	}
}
