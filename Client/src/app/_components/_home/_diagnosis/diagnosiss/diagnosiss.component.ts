import { RepositoryService } from 'src/app/_services';
import { Diagnosis } from 'src/app/_models';
import { DiagnosisEditDialogComponent } from './../diagnosis-edit-dialog/diagnosis-edit-dialog.component';
import { DiagnosisAddDialogComponent } from '../diagnosis-add-dialog/diagnosis-add-dialog.component';
import { DiagnosisDeleteDialogComponent } from '../diagnosis-delete-dialog/diagnosis-delete-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';

@Component({
  selector: 'app-diagnosiss',
  templateUrl: './diagnosiss.component.html',
  styleUrls: ['./diagnosiss.component.css']
})

export class DiagnosissComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['name', 'edit', 'delete'];
  diagnosiss: Diagnosis[];
  dataSource = new MatTableDataSource<Diagnosis>();

  constructor(private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getDiagnosiss();
  }

  getDiagnosiss() {
    this.repository.get('diagnosiss').subscribe(
      (res: any) => {
        this.diagnosiss = res;
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
    const dialogRef = this.dialog.open(DiagnosisAddDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.diagnosiss.push(result);
        this.refeshData();
      }
    });
  }

  edit(diagnosis) {
    const dialogRef = this.dialog.open(DiagnosisEditDialogComponent, {
      data: diagnosis
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.diagnosiss.findIndex(f => f.id === result.id);
        this.diagnosiss[index] = result;
        this.refeshData();
      }
    });
  }

  delete(diagnosis) {
    const dialogRef = this.dialog.open(DiagnosisDeleteDialogComponent, {
      data: diagnosis
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.diagnosiss.findIndex(f => f.id === result.id);
        this.diagnosiss.splice(index, 1);
        this.refeshData();
      }
    });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.diagnosiss);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
