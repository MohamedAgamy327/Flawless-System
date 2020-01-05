import { RepositoryService } from 'src/app/_services';
import { Test } from 'src/app/_models';
import { TestEditDialogComponent } from './../test-edit-dialog/test-edit-dialog.component';
import { TestAddDialogComponent } from '../test-add-dialog/test-add-dialog.component';
import { TestDeleteDialogComponent } from '../test-delete-dialog/test-delete-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.component.html',
  styleUrls: ['./tests.component.css']
})

export class TestsComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['name', 'edit', 'delete'];
  tests: Test[];
  dataSource = new MatTableDataSource<Test>();

  constructor(private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getTests();
  }

  getTests() {
    this.repository.get('tests').subscribe(
      (res: any) => {
        this.tests = res;
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
    const dialogRef = this.dialog.open(TestAddDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.tests.push(result);
        this.refeshData();
      }
    });
  }

  edit(test) {
    const dialogRef = this.dialog.open(TestEditDialogComponent, {
      data: test
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.tests.findIndex(f => f.id === result.id);
        this.tests[index] = result;
        this.refeshData();
      }
    });
  }

  delete(test) {
    const dialogRef = this.dialog.open(TestDeleteDialogComponent, {
      data: test
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.tests.findIndex(f => f.id === result.id);
        this.tests.splice(index, 1);
        this.refeshData();
      }
    });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.tests);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
