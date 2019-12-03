import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';
import { RepositoryService } from 'src/app/_services';
import { MustMatch } from 'src/app/_helpers/must-match.validator';

@Component({
  selector: 'app-user-change-password-dialog',
  templateUrl: './user-change-password-dialog.component.html',
  styleUrls: ['./user-change-password-dialog.component.css']
})

export class UserChangePasswordDialogComponent  {

  changePasswordForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private dialogRef: MatDialogRef<UserChangePasswordDialogComponent>,
              @Inject(MAT_DIALOG_DATA) private data: any, private repository: RepositoryService, private snackBar: MatSnackBar) {
    this.createForm();
  }

  createForm() {
    this.changePasswordForm = this.formBuilder.group({
      id: [this.data],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]]
    },
    {
      validator: MustMatch('password', 'confirmPassword')
    });
  }

  public errorHandling = (control: string, error: string) => {
    return this.changePasswordForm.controls[control].hasError(error);
  }

  change() {
    this.repository.put('users/changepassword', this.changePasswordForm.value).subscribe(
      (res: any) => {
        this.snackBar.open('changed Successfully', '', {
          duration: 1000,
          panelClass: ['green-snackbar']
        });
        this.dialogRef.close(res);
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  cancel(): void {
    this.dialogRef.close();
  }

}
