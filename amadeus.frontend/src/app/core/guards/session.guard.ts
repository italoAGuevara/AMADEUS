import {CanActivateFn, Router} from '@angular/router';
import {GlobalSettings} from "../globalSettings";

export const sessionGuard: CanActivateFn = (route, state) => {

 // const router : Router;

  const token : string = GlobalSettings.token;

  if(token !== '' && token !== null){
    return true;
  }

  return false;
};
