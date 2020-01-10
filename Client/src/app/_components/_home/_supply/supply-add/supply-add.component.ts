import { Component, OnInit } from '@angular/core';
import { MatSnackBar, MatTableDataSource } from '@angular/material';
import { RepositoryService } from 'src/app/_services';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { SupplyItem, Item } from 'src/app/_models';

@Component({
  selector: 'app-supply-add',
  templateUrl: './supply-add.component.html',
  styleUrls: ['./supply-add.component.css']
})

export class SupplyAddComponent implements OnInit {

  // Table
  supplyItems: SupplyItem[] = [];
  dataSource = new MatTableDataSource<SupplyItem>();
  displayedColumns: string[] = ['name', 'quantity', 'cost', 'price', 'edit', 'delete'];

  // Drop Down List
  items: Item[];

  // forms
  supplyForm: FormGroup;
  itemForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private repository: RepositoryService, private snackBar: MatSnackBar) {
    this.createSupplyForm();
    this.createItemForm();
    this.onItemChange();
    this.refeshData();
  }

  ngOnInit() {
    this.getItems();
  }

  createSupplyForm() {
    this.supplyForm = this.formBuilder.group({
      notes: [''],
      supplyItems: this.formBuilder.array([])
    }
    );
  }

  createItemForm() {
    this.itemForm = this.formBuilder.group({
      itemId: [, Validators.required],
      name: ['', Validators.required],
      quantity: [, [Validators.required]],
      cost: [, [Validators.required]],
      price: [, [Validators.required]]
    }
    );
  }

  public errorHandling = (control: string, error: string) => {
    return this.itemForm.controls[control].hasError(error);
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
        this.itemForm.controls.name.setValue(item.name);
        this.itemForm.controls.price.setValue(item.price);
        this.itemForm.controls.cost.setValue(item.cost);
      } else {
        this.itemForm.controls.name.setValue('');
        this.itemForm.controls.price.setValue(null);
        this.itemForm.controls.cost.setValue(null);
      }
    });
  }

  refeshData() {
    this.dataSource = new MatTableDataSource(this.supplyItems);
  }

  resetSupplyForm() {
    (<FormArray>this.supplyForm.get('supplyItems')).clear();
    this.supplyForm.patchValue({ notes: ''});
    this.supplyForm.markAsPristine();
    this.supplyForm.markAsUntouched();
  }

  resetItemForm() {
    this.itemForm.setValue({ itemId: null, name: '', quantity: null, cost: null, price: null });
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
    const index = this.supplyItems.findIndex(f => f.itemId === item.id);
    this.supplyItems.splice(index, 1);
    this.supplyItemsArray.removeAt(this.supplyItemsArray.value.findIndex(i => i.id === item.id));
    this.refeshData();
  }

  save() {
    this.repository.post('supplies', this.supplyForm.value).subscribe(
      (res: any) => {
        this.resetItemForm();
        this.resetSupplyForm();
        this.supplyItems = [];
        this.refeshData();
        this.snackBar.open('Added Successfully', '', {
          duration: 1000,
          panelClass: ['green-snackbar']
        });
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

}
