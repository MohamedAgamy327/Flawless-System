import { RepositoryService } from 'src/app/_services';
import { Item } from 'src/app/_models';
import { ItemEditDialogComponent } from './../item-edit-dialog/item-edit-dialog.component';
import { ItemAddDialogComponent } from '../item-add-dialog/item-add-dialog.component';
import { ItemDeleteDialogComponent } from '../item-delete-dialog/item-delete-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})

export class ItemsComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['name', 'quantity', 'cost', 'price', 'edit', 'delete'];
  items: Item[];
  dataSource = new MatTableDataSource<Item>();

  constructor(private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.repository.get('items').subscribe(
      (res: any) => {
        this.items = res;
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
    const dialogRef = this.dialog.open(ItemAddDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.items.push(result);
        this.refeshData();
      }
    });
  }

  edit(item) {
    const dialogRef = this.dialog.open(ItemEditDialogComponent, {
      data: item
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.items.findIndex(f => f.id === result.id);
        this.items[index] = result;
        this.refeshData();
      }
    });
  }

  delete(item) {
    const dialogRef = this.dialog.open(ItemDeleteDialogComponent, {
      data: item
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.items.findIndex(f => f.id === result.id);
        this.items.splice(index, 1);
        this.refeshData();
      }
    });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.items);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
