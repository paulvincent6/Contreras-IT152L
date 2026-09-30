import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

import { AuthServiceService } from '../../services/auth.service';
import { TokenStorageService } from '../../services/token-storage.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  form: any = {
    username: null,
    password: null
  }

  constructor(
    private authService: AuthServiceService,
    private tokenStorage: TokenStorageService,
    private http: HttpClient,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.authService.isLoggedIn = true;
      this.router.navigate([this.authService.redirectUrl]);
    }
  }

  onSubmit() {
    const { username, password } = this.form;

    this.http.post(
      "https://localhost:7126/api/Login",
      { username, password },
      { responseType: 'text' }
    ).subscribe(data => {

      this.tokenStorage.saveToken(data);

      this.authService.isLoggedIn = true;

      this.router.navigate(['/']);

      window.location.reload();
    });
  }
}

export interface LoginPostData {
  id_token: string;
  id: number;
}