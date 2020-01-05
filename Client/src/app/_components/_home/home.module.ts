import { RolePipe } from './../../_custom-pipes/role.pipe';
import { GenderPipe } from 'src/app/_custom-pipes/gender.pipe';
import { AngularMaterialModule } from 'src/app/shared/material.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddSpacePipe } from 'src/app/_custom-pipes/add-space.pipe';
import { CredentialService } from 'src/app/_services';
import {
  HomeComponent, LandingComponent, UserAddDialogComponent,
  UserChangePasswordDialogComponent, UserDeleteDialogComponent,
  UserEditDialogComponent, UsersComponent,
  ItemAddDialogComponent, ItemDeleteDialogComponent, ItemEditDialogComponent, ItemsComponent,
  MedicineAddDialogComponent, MedicineDeleteDialogComponent, MedicineEditDialogComponent, MedicinesComponent,
  PatientAddDialogComponent, PatientDeleteDialogComponent, PatientEditDialogComponent, PatientsComponent,
  SpendingAddDialogComponent, SpendingDeleteDialogComponent, SpendingEditDialogComponent, SpendingsComponent,
  TestsComponent, TestAddDialogComponent, TestEditDialogComponent, TestDeleteDialogComponent,
  DiagnosissComponent, DiagnosisAddDialogComponent, DiagnosisEditDialogComponent, DiagnosisDeleteDialogComponent,
  FrequencysComponent, FrequencyAddDialogComponent, FrequencyEditDialogComponent, FrequencyDeleteDialogComponent
} from '.';


@NgModule({
  declarations: [
    AddSpacePipe,
    RolePipe,
    GenderPipe,
    HomeComponent,
    LandingComponent,
    UserChangePasswordDialogComponent, UserDeleteDialogComponent,
    UserEditDialogComponent, UsersComponent, UserAddDialogComponent,
    ItemAddDialogComponent, ItemDeleteDialogComponent, ItemEditDialogComponent, ItemsComponent,
    MedicineAddDialogComponent, MedicineDeleteDialogComponent, MedicineEditDialogComponent, MedicinesComponent,
    PatientAddDialogComponent, PatientDeleteDialogComponent, PatientEditDialogComponent, PatientsComponent,
    SpendingAddDialogComponent, SpendingDeleteDialogComponent, SpendingEditDialogComponent, SpendingsComponent,
    TestsComponent, TestAddDialogComponent, TestEditDialogComponent, TestDeleteDialogComponent,
    DiagnosissComponent, DiagnosisAddDialogComponent, DiagnosisEditDialogComponent, DiagnosisDeleteDialogComponent,
    FrequencysComponent, FrequencyAddDialogComponent, FrequencyEditDialogComponent, FrequencyDeleteDialogComponent
  ],
  entryComponents: [
    UserChangePasswordDialogComponent, UserDeleteDialogComponent,
    UserEditDialogComponent, UserAddDialogComponent,
    ItemAddDialogComponent, ItemDeleteDialogComponent, ItemEditDialogComponent,
    MedicineAddDialogComponent, MedicineDeleteDialogComponent, MedicineEditDialogComponent,
    PatientAddDialogComponent, PatientDeleteDialogComponent, PatientEditDialogComponent,
    SpendingAddDialogComponent, SpendingDeleteDialogComponent, SpendingEditDialogComponent,
    TestAddDialogComponent, TestEditDialogComponent, TestDeleteDialogComponent,
    DiagnosisAddDialogComponent, DiagnosisEditDialogComponent, DiagnosisDeleteDialogComponent
    , FrequencyAddDialogComponent, FrequencyEditDialogComponent, FrequencyDeleteDialogComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    ReactiveFormsModule,
    AngularMaterialModule
  ],
  providers: [CredentialService]
})
export class HomeModule { }
