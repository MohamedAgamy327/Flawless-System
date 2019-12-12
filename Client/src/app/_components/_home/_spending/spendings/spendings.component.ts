import { RepositoryService } from 'src/app/_services';
import { Spending } from 'src/app/_models';
import { SpendingEditDialogComponent } from './../spending-edit-dialog/spending-edit-dialog.component';
import { SpendingAddDialogComponent } from '../spending-add-dialog/spending-add-dialog.component';
import { SpendingDeleteDialogComponent } from '../spending-delete-dialog/spending-delete-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';

@Component({
  selector: 'app-spendings',
  templateUrl: './spendings.component.html',
  styleUrls: ['./spendings.component.css']
})

export class SpendingsComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = [ 'statement', 'date', 'amount', 'edit', 'delete'];
  spendings: Spending[];
  dataSource = new MatTableDataSource<Spending>();

  constructor(private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getSpendings();
  }

  getSpendings() {
    this.repository.get('spendings').subscribe(
      (res: any) => {
        this.spendings = res;
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
    const dialogRef = this.dialog.open(SpendingAddDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.spendings.push(result);
        this.refeshData();
      }
    });
  }

  edit(spending) {
    const dialogRef = this.dialog.open(SpendingEditDialogComponent, {
      data: spending
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.spendings.findIndex(f => f.id === result.id);
        this.spendings[index] = result;
        this.refeshData();
      }
    });
  }

  delete(spending) {
    const dialogRef = this.dialog.open(SpendingDeleteDialogComponent, {
      data: spending
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.spendings.findIndex(f => f.id === result.id);
        this.spendings.splice(index, 1);
        this.refeshData();
      }
    });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.spendings);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
