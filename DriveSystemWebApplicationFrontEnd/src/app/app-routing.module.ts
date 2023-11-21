import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotFoundComponent } from 'src/Components/not-found/not-found.component';
import { ContactsComponent } from 'src/Components/contacts/contacts.component';
import { RegisterComponent } from 'src/Components/register/register.component';
import { LoginComponent } from 'src/Components/login/login.component';
import { routeGuardGuard } from '../services/route-guard.guard';

const routes: Routes = [
  { path: '', component: LoginComponent },

  { path: 'conacts', component: ContactsComponent },
  { path: 'register', component: RegisterComponent },
  {path: 'login' , component: LoginComponent},
  { path: '**', component:NotFoundComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
