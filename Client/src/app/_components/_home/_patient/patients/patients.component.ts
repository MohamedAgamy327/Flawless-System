import { RepositoryService } from 'src/app/_services';
import { Patient } from 'src/app/_models';
import { PatientEditDialogComponent } from './../patient-edit-dialog/patient-edit-dialog.component';
import { PatientAddDialogComponent } from '../patient-add-dialog/patient-add-dialog.component';
import { PatientDeleteDialogComponent } from '../patient-delete-dialog/patient-delete-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css']
})

export class PatientsComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['name', 'telephone', 'birthday', 'gender', 'edit', 'delete'];
  patients: Patient[];
  dataSource = new MatTableDataSource<Patient>();

  constructor(private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getPatients();
  }

  getPatients() {
    this.repository.get('patients').subscribe(
      (res: any) => {
        this.patients = res;
        this.refeshData();
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  add() {
    const dialogRef = this.dialog.open(PatientAddDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.patients.push(result);
        this.refeshData();
      }
    });
  }

  edit(patient) {
    const dialogRef = this.dialog.open(PatientEditDialogComponent, {
      data: patient
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.patients.findIndex(f => f.id === result.id);
        this.patients[index] = result;
        this.refeshData();
      }
    });
  }

  delete(patient) {
    const dialogRef = this.dialog.open(PatientDeleteDialogComponent, {
      data: patient
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.patients.findIndex(f => f.id === result.id);
        this.patients.splice(index, 1);
        this.refeshData();
      }
    });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.patients);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
