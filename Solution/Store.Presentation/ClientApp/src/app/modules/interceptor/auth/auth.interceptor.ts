import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

	constructor(private router: Router) { }

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

		var token = localStorage.getItem('refreshToken');

		if (token === null) {
			return next.handle(request.clone());
		}
		const clonedReq = request.clone({
			headers: request.headers.set('Authorization', 'Bearer ' + localStorage.getItem('refreshToken'))
		});

		return next.handle(clonedReq).pipe(
			tap(
				succ => { },
				err => {
					if (err.status == 401) {
						localStorage.removeItem('refreshToken');
						this.router.navigateByUrl('/user/login');
					}
					if (err.status == 403) {
						this.router.navigateByUrl('/forbidden');
					}
				}
			)
		)

	}
}

