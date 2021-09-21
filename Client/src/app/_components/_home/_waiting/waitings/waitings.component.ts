import { Patient } from './../../../../_models/_patient/patient.model';
import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/_services';
import { MatSnackBar, MatDialog, MatTableDataSource } from '@angular/material';
import { PatientAddDialogComponent } from '../../_patient/patient-add-dialog/patient-add-dialog.component';
import { Waiting } from 'src/app/_models';


@Component({
  selector: 'app-waitings',
  templateUrl: './waitings.component.html',
  styleUrls: ['./waitings.component.css']
})
export class WaitingsComponent implements OnInit {

  patient: Patient;
  waitings: Waiting[];
  dataSource = new MatTableDataSource<Waiting>();
  displayedColumns: string[] = ['name', 'telephone', 'arrivalDate', 'up', 'down', 'cancel', 'enter'];

  constructor(private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getWaitings();
  }

  getWaitings() {
    this.repository.get('waitings').subscribe(
      (res: any) => {
        this.waitings = res;
        this.refeshData();
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.waitings);
  }

  search(val: string) {
    this.repository.get(`patients/bytelephone/${val}`).subscribe(
      (res: any) => {
        this.patient = res;
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  clearPatient() {
    this.patient = null;
  }

  addNewPatient() {
    const dialogRef = this.dialog.open(PatientAddDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {

    });
  }

  addWaiting() {
    const waiting = { patientId: this.patient.id };
    this.repository.post('waitings', waiting).subscribe(
      (res: any) => {
        this.snackBar.open('Added Successfully', '', {
          duration: 1000,
          panelClass: ['green-snackbar']
        });
        this.waitings.push(res);
        this.patient = null;
        this.refeshData();
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  moveUp(index: number) {
    if (index >= 1) {
      this.swap(this.waitings, index, index - 1);
      this.refeshData();
    }
  }

  moveDown(index: number) {
    if (index < this.waitings.length - 1) {
      this.swap(this.waitings, index, index + 1);
      this.refeshData();
    }
  }

  private swap(array: any[], x: any, y: any) {
    const b = array[x];
    array[x] = array[y];
    array[y] = b;
  }
}
