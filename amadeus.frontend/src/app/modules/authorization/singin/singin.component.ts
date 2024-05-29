import {Component, OnInit} from '@angular/core';
import {FormsModule} from "@angular/forms";
import {InputTextModule} from "primeng/inputtext";
import {CheckboxModule} from "primeng/checkbox";
import {ButtonModule} from "primeng/button";
import {RippleModule} from "primeng/ripple";
import {GlobalSettings} from "../../../core/globalSettings";
import {Router} from "@angular/router";
import {MessagesModule} from "primeng/messages";
import {Message} from "primeng/api";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {LoginService} from "../services/login.service";
import {SinginPetition} from "../../../core/entities/Login";

@Component({
  selector: 'app-singin',
  standalone: true,
  imports: [
    FormsModule,
    InputTextModule,
    CheckboxModule,
    ButtonModule,
    RippleModule,
    MessagesModule,
  ],
  templateUrl: './singin.component.html',
  styleUrl: './singin.component.css'
})
export class SinginComponent implements OnInit  {

  userName : string = '';
  password : string = '';

  bodySinginPetition : SinginPetition = {email : this.userName, password : this.password}

  messages: Message[] = [];

  constructor(
    private router: Router,
    private _login : LoginService
  ) {}

  ngOnInit() {
    this.messages = [];
  }

  login(){

    this.bodySinginPetition  = {email : this.userName, password : this.password}

    if (!this.validateEmail(this.userName)){
      console.log('pepe')
      this.messages = [{ severity: 'error', detail: 'El usuario no tiene el formato correcto' }];
      return;
    }

    if(this.password === ''){
      this.messages = [{ severity: 'warn', detail: 'La contraseña es requerida' }]
      return;
    }

    //TODO : Validate user using the service
    this._login.singIn(this.bodySinginPetition).subscribe({
      next : (result) => {
        GlobalSettings.token = result.token;
        GlobalSettings.userName = this.userName;
        GlobalSettings.userEmail = this.userName;

        this.router.navigate(['/']);
      },
      error : (error) => {
        this.messages = [{ severity: 'warn', detail: error.error.detail }]
      },
      complete : () => {

      }
    })
  }

  private validateEmail(email : string) {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailRegex.test(email);
  }

}
