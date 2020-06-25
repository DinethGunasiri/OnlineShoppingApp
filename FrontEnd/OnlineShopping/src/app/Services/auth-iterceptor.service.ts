import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor(private cookieSrvice: CookieService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const idToken = this.cookieSrvice.get('Token');
    // sessionStorage.getItem('Token');
    if (idToken) {
            const cloned = req.clone({
                setHeaders: {
                  Authorization: `Bearer ${idToken}`
                }
            });

            return next.handle(cloned);
        }
    else {
            return next.handle(req);
        }
  }
}
