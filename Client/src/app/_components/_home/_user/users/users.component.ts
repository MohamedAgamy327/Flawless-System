import { RepositoryService } from 'src/app/_services';
import { User } from 'src/app/_models';
import { UserEditDialogComponent } from './../user-edit-dialog/user-edit-dialog.component';
import { UserAddDialogComponent } from '../user-add-dialog/user-add-dialog.component';
import { UserDeleteDialogComponent } from '../user-delete-dialog/user-delete-dialog.component';
// tslint:disable-next-line: import-spacing
import { UserChangePasswordDialogComponent }
  from '../user-change-password-dialog/user-change-password-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})

export class UsersComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  displayedColumns: string[] = ['name', 'role', 'edit', 'delete', 'changePassword'];
  users: User[];
  dataSource = new MatTableDataSource<User>();

  constructor(private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.repository.get('users').subscribe(
      (res: any) => {
        this.users = res;
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
    const dialogRef = this.dialog.open(UserAddDialogComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.users.push(result);
        this.refeshData();
      }
    });
  }

  edit(user) {
    const dialogRef = this.dialog.open(UserEditDialogComponent, {
      data: user
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.users.findIndex(f => f.id === result.id);
        this.users[index] = result;
        this.refeshData();
      }
    });
  }

  changePassword(id) {
    const dialogRef = this.dialog.open(UserChangePasswordDialogComponent, {
      data: id
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.users.findIndex(f => f.id === result.id);
        this.users[index] = result;
        this.refeshData();
      }
    });
  }

  delete(user) {
    const dialogRef = this.dialog.open(UserDeleteDialogComponent, {
      data: user
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const index = this.users.findIndex(f => f.id === result.id);
        this.users.splice(index, 1);
        this.refeshData();
      }
    });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.users);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

}
