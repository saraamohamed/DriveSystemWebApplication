import { CanActivateFn,Router } from '@angular/router';
import { LoginService } from './login.Service';
import { inject } from '@angular/core';


export const routeGuardGuard: CanActivateFn = (route, state) => {
  const test=inject(LoginService).checkUserLogin();
  if (test=="true"){
    console.log(test);
    
  return true;}
else {
  console.log(test);  
  alert("Log in first!");
  inject(Router).navigate(['/login'])
  return false;
}
};
