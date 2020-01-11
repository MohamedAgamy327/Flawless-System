import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatTableDataSource } from '@angular/material';
import { RepositoryService } from 'src/app/_services';
import { SupplyItemGet, Supply } from 'src/app/_models';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-supply-delete',
  templateUrl: './supply-delete.component.html',
  styleUrls: ['./supply-delete.component.css']
})

export class SupplyDeleteComponent implements OnInit {

  supply: Supply;
  supplyItems: SupplyItemGet[] = [];
  dataSource = new MatTableDataSource<SupplyItemGet>();
  displayedColumns: string[] = ['name', 'quantity', 'cost', 'price'];


  constructor(private router: Router, private route: ActivatedRoute, private repository: RepositoryService,
              private snackBar: MatSnackBar) {

  }

  ngOnInit() {
    this.getSupply(this.route.snapshot.params.id);
    this.getSupplyItems(this.route.snapshot.params.id);
  }

  getSupply(id) {
    this.repository.get(`supplies/${id}`).subscribe(
      (res: any) => {
        this.supply = res;
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  getSupplyItems(id) {
    this.repository.get(`supplies/${id}/items`).subscribe(
      (res: any) => {
        this.supplyItems = res;
        this.dataSource = new MatTableDataSource(this.supplyItems);
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  delete() {
    this.repository.delete(`supplies/${this.route.snapshot.params.id}`).subscribe(
      (res: any) => {
        this.router.navigate(['/home/supplies']);
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

}
