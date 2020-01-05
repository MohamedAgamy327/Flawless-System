import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { RepositoryService } from 'src/app/_services';

@Component({
  selector: 'app-test-delete-dialog',
  templateUrl: './test-delete-dialog.component.html',
  styleUrls: ['./test-delete-dialog.component.css']
})

export class TestDeleteDialogComponent {


  constructor(private dialogRef: MatDialogRef<TestDeleteDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any, private repository: RepositoryService, private snackBar: MatSnackBar) { }

  cancel(): void {
    this.dialogRef.close();
  }

  confirmDelete(): void {
    this.repository.delete(`tests/${this.data.id}`).subscribe(
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
