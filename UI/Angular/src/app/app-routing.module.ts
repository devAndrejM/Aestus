import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {PutninalogComponent} from './putninalog/putninalog.component';
import {PutnikComponent} from './putnik/putnik.component';

const routes: Routes = [
  {path:'putninalozi',component:PutninalogComponent},
  {path:'putnici',component:PutnikComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
