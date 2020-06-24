import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const idToken = sessionStorage.getItem('Token');
    console.log(idToken);
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
