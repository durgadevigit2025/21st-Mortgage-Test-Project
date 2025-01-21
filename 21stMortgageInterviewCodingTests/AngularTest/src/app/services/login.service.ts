import { Injectable } from '@angular/core';
import { ILoginResult } from '../models/login-result.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  login(username: string, password: string): Promise<ILoginResult> {
    return new Promise((resolve) => {
      // Simulate an API call
      if (username === 'admin' && password === 'admin') {
        resolve({ loginSuccessful: true });
      } else {
        resolve({ loginSuccessful: false });
      }
    });
  }
}
