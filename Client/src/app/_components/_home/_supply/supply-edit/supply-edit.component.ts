import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatTableDataSource } from '@angular/material';
import { RepositoryService } from 'src/app/_services';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { SupplyItemGet, Item, Supply } from 'src/app/_models';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-supply-edit',
  templateUrl: './supply-edit.component.html',
  styleUrls: ['./supply-edit.component.css']
})

export class SupplyEditComponent implements OnInit {

  supply: Supply;
  // Table
  supplyItems: SupplyItemGet[] = [];
  dataSource = new MatTableDataSource<SupplyItemGet>();
  displayedColumns: string[] = ['name', 'quantity', 'cost', 'price', 'edit', 'delete'];

  // Drop Down List
  items: Item[];

  // forms
  supplyForm: FormGroup;
  itemForm: FormGroup;

  constructor(private router: Router, private route: ActivatedRoute,
              private formBuilder: FormBuilder, private repository: RepositoryService, private snackBar: MatSnackBar) {
    this.createSupplyForm();
    this.createItemForm();
    this.onItemChange();
  }

  ngOnInit() {
    this.getItems();
    this.getSupply(this.route.snapshot.params.id);
    this.getSupplyItems(this.route.snapshot.params.id);
  }

  createSupplyForm() {
    this.supplyForm = this.formBuilder.group({
      id: [],
      notes: [''],
      supplyItems: this.formBuilder.array([])
    }
    );
  }

  createItemForm() {
    this.itemForm = this.formBuilder.group({
      supplyId: [, Validators.required],
      itemId: [, Validators.required],
      itemName: ['', Validators.required],
      quantity: [, [Validators.required]],
      cost: [, [Validators.required]],
      price: [, [Validators.required]]
    }
    );
  }

  public errorHandling = (control: string, error: string) => {
    return this.itemForm.controls[control].hasError(error);
  }

  getSupply(id) {
    this.repository.get(`supplies/${id}`).subscribe(
      (res: any) => {
        this.supply = res;
        this.fillSupplyForm();
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  fillSupplyForm() {
    this.supplyForm.patchValue({
      id: this.supply.id,
      notes: this.supply.notes
    });
  }

  getSupplyItems(id) {
    this.repository.get(`supplies/${id}/items`).subscribe(
      (res: any) => {
        this.supplyItems = res;
        this.fillSuppyItemsForm();
        this.refeshData();
        console.log(this.supplyForm.value);

      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  fillSuppyItemsForm() {
    const supplyItemControl = (this.supplyForm.get('supplyItems') as FormArray);
    this.supplyItems.forEach(element => {
      supplyItemControl.push(this.formBuilder.group(element));
    });
  }

  getItems() {
    this.repository.get('items').subscribe(
      (res: any) => {
        this.items = res;
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  onItemChange(): void {
    this.itemForm.controls.itemId.valueChanges.subscribe((value) => {
      if (value) {
        const item = this.items[this.items.findIndex(f => f.id === value)];
        this.itemForm.controls.itemName.setValue(item.name);
        this.itemForm.controls.price.setValue(item.price);
        this.itemForm.controls.cost.setValue(item.cost);
      } else {
        this.itemForm.controls.itemName.setValue('');
        this.itemForm.controls.price.setValue(null);
        this.itemForm.controls.cost.setValue(null);
      }
    });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.supplyItems);
  }

  resetItemForm() {
    this.itemForm.setValue({ supplyId: null, itemId: null, itemName: '', quantity: null, cost: null, price: null });
    this.itemForm.markAsPristine();
    this.itemForm.markAsUntouched();
  }

  get supplyItemsArray(): FormArray {
    return this.supplyForm.controls.supplyItems as FormArray;
  }

  addSupplyItem() {
    this.supplyItems.push(this.itemForm.value);
    const control = this.supplyForm.controls.supplyItems as FormArray;
    control.push(
      this.formBuilder.group({
        supplyId: this.supply.id,
        itemId: this.itemForm.value.itemId,
        quantity: this.itemForm.value.quantity,
        cost: this.itemForm.value.cost,
        price: this.itemForm.value.price
      })
    );
    this.refeshData();
    this.resetItemForm();
  }

  deleteItem(id) {
    const index = this.supplyItems.findIndex(f => f.itemId === id);
    this.supplyItems.splice(index, 1);
    this.supplyItemsArray.removeAt(this.supplyItemsArray.value.findIndex(item => item.id === id));
    this.refeshData();
  }

  editItem(item) {
    this.itemForm.setValue(item);
    const index = this.supplyItems.findIndex(f => f.itemId === item.itemId);
    this.supplyItems.splice(index, 1);
    this.supplyItemsArray.removeAt(this.supplyItemsArray.value.findIndex(i => i.id === item.id));
    this.refeshData();
  }

  update() {
    this.repository.put('supplies', this.supplyForm.value).subscribe(
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
