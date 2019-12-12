import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent , LandingComponent, UsersComponent, ItemsComponent, MedicinesComponent, PatientsComponent } from '.';

const routes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      {
        path: '', component: LandingComponent
      },
      {
        path: 'users', component: UsersComponent
      },
      {
        path: 'patients', component: PatientsComponent
      },
      {
        path: 'items', component: ItemsComponent
      },
      {
        path: 'medicines', component: MedicinesComponent
      },
      {
        path: '', redirectTo: '', pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
