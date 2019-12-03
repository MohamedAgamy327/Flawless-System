import { RolePipe } from './../../_custom-pipes/role.pipe';
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
  UserEditDialogComponent, UsersComponent
} from '.';

@NgModule({
  declarations: [
    AddSpacePipe,
    RolePipe,
    HomeComponent,
    LandingComponent,
    UserChangePasswordDialogComponent, UserDeleteDialogComponent,
    UserEditDialogComponent, UsersComponent, UserAddDialogComponent
  ],
  entryComponents: [
    UserChangePasswordDialogComponent, UserDeleteDialogComponent,
    UserEditDialogComponent, UserAddDialogComponent
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
