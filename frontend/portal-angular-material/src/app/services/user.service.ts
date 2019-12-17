import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserRequest } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private readonly urlLogin: string = environment.api_base_url + environment.url_login;
  private readonly urlRegisterUser: string = environment.api_base_url + environment.url_register_user;

  constructor(private http: HttpClient) { }

  public login(email: string, password: string) {

    let payload = { email, password };

    return this.http.post(this.urlLogin, payload);
  }

  public registerUser(user: UserRequest) {

    return this.http.post(this.urlRegisterUser, user);
  }


}
