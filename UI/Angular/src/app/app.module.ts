import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PutninalogComponent } from './putninalog/putninalog.component';
import { ShowNalogComponent } from './putninalog/show-nalog/show-nalog.component';
import { AddEditNalogComponent } from './putninalog/add-edit-nalog/add-edit-nalog.component';
import { PutnikComponent } from './putnik/putnik.component';
import { ShowPutnikComponent } from './putnik/show-putnik/show-putnik.component';
import { AddEditPutnikComponent } from './putnik/add-edit-putnik/add-edit-putnik.component';
import{SharedService} from './shared.service';


import {NgxMaterialTimepickerModule} from 'ngx-material-timepicker';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from '@danielmoncada/angular-datetime-picker';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    PutninalogComponent,
    ShowNalogComponent,
    AddEditNalogComponent,
    PutnikComponent,
    ShowPutnikComponent,
    AddEditPutnikComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    [NgxMaterialTimepickerModule],
    OwlDateTimeModule, 
         OwlNativeDateTimeModule,
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
