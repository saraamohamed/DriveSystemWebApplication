import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { NavbarComponent } from 'src/Components/navbar/navbar.component';
import { FooterComponent } from 'src/Components/footer/footer.component';
import { NotFoundComponent } from 'src/Components/not-found/not-found.component';
import { ContactsComponent } from 'src/Components/contacts/contacts.component';
import { RegisterComponent } from 'src/Components/register/register.component';
import { LoginComponent } from 'src/Components/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
   NotFoundComponent,ContactsComponent,
    RegisterComponent,
    LoginComponent,

  ],
  imports: [
    BrowserModule,RouterModule,
    AppRoutingModule,HttpClientModule, CommonModule,
    FormsModule,ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
