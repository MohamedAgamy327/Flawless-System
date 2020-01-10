import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  HomeComponent, LandingComponent, UsersComponent, ItemsComponent,
  MedicinesComponent, PatientsComponent, SpendingsComponent, TestsComponent, DiagnosissComponent,
  FrequencysComponent, MedicineTypesComponent, SuppliesComponent, SupplyAddComponent
} from '.';

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
        path: 'tests', component: TestsComponent
      },
      {
        path: 'diagnosis', component: DiagnosissComponent
      },
      {
        path: 'frequency', component: FrequencysComponent
      },
      {
        path: 'medicinestypes', component: MedicineTypesComponent
      },
      {
        path: 'medicines', component: MedicinesComponent
      },
      {
        path: 'spending', component: SpendingsComponent
      },
      {
        path: 'items', component: ItemsComponent
      },
      {
        path: 'supplies', component: SuppliesComponent
      },
      {
        path: 'supplyadd', component: SupplyAddComponent
      },
      // {
      //   path: 'supply', component: ItemsComponent
      // },
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
