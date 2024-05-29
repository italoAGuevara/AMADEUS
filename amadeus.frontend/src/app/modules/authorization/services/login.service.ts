import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SinginPetition, SinginResponse} from "../../../core/entities/Login";
import {Observable} from "rxjs";
import {environment} from "../../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http :  HttpClient) { }

  singIn(body : SinginPetition): Observable<SinginResponse>{
    return this.http.post<SinginResponse>(environment.APIauthenticaion + '/auth', body)
  }
}
