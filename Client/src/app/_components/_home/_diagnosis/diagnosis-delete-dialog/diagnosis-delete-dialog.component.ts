import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { RepositoryService } from 'src/app/_services';

@Component({
  selector: 'app-diagnosis-delete-dialog',
  templateUrl: './diagnosis-delete-dialog.component.html',
  styleUrls: ['./diagnosis-delete-dialog.component.css']
})

export class DiagnosisDeleteDialogComponent {


  constructor(private dialogRef: MatDialogRef<DiagnosisDeleteDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any, private repository: RepositoryService, private snackBar: MatSnackBar) { }

  cancel(): void {
    this.dialogRef.close();
  }

  confirmDelete(): void {
    this.repository.delete(`diagnosiss/${this.data.id}`).subscribe(
      (res: any) => {
        this.snackBar.open('Deleted Successfully', '', {
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

}
