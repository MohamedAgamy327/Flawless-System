import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RepositoryService } from 'src/app/_services';
import { MatDialogRef, MatSnackBar, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-diagnosis-add-dialog',
  templateUrl: './diagnosis-add-dialog.component.html',
  styleUrls: ['./diagnosis-add-dialog.component.css']
})

export class DiagnosisAddDialogComponent {

  addForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private dialogRef: MatDialogRef<DiagnosisAddDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any, private repository: RepositoryService, private snackBar: MatSnackBar) {
    this.createForm();
  }

  createForm() {
    this.addForm = this.formBuilder.group({
      name: ['', Validators.required]
    }
    );
  }

  public errorHandling = (control: string, error: string) => {
    return this.addForm.controls[control].hasError(error);
  }

  save() {
    this.repository.post('diagnosiss', this.addForm.value).subscribe(
      (res: any) => {
        this.snackBar.open('Added Successfully', '', {
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
