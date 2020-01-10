import { RepositoryService } from 'src/app/_services';
import { Supply } from 'src/app/_models';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';

@Component({
  selector: 'app-supplies',
  templateUrl: './supplies.component.html',
  styleUrls: ['./supplies.component.css']
})

export class SuppliesComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['notes', 'date', 'edit', 'delete'];
  supplies: Supply[];
  dataSource = new MatTableDataSource<Supply>();

  constructor(private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getSupplies();
  }

  getSupplies() {
    this.repository.get('supplies').subscribe(
      (res: any) => {
        this.supplies = res;
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

  refeshData() {
    this.dataSource = new MatTableDataSource(this.supplies);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
