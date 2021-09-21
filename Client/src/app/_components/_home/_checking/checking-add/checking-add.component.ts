import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/_models/_patient/patient.model';
import { RepositoryService } from 'src/app/_services';
import { MatSnackBar, MatDialog } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-checking-add',
  templateUrl: './checking-add.component.html',
  styleUrls: ['./checking-add.component.css']
})
export class CheckingAddComponent implements OnInit {

  // patient
  patient: Patient;

  // checking
  checkingForm: FormGroup;


  constructor(private router: Router, private formBuilder: FormBuilder, private route: ActivatedRoute,
              private repository: RepositoryService, private snackBar: MatSnackBar, private dialog: MatDialog) {
    this.createCheckingForm();
  }

  ngOnInit() {
    this.getPatient(this.route.snapshot.params.patientId);
  }

  getPatient(patientId) {
    this.repository.get(`patients/${patientId}`).subscribe(
      (res: any) => {
        this.patient = res;
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });
  }

  createCheckingForm() {
    this.checkingForm = this.formBuilder.group({
      patientId: [Number(this.route.snapshot.params.patientId)],
      visitDate: [],
      nextVisitDate: [],
      visitType: [''],
      diagonsis: [''],
      // PrescriptionMedicines: this.formBuilder.array([]),
      // PrescriptionInstructions: this.formBuilder.array([])
    }
    );
  }

  public checkingErrorHandling = (control: string, error: string) => {
    return this.checkingForm.controls[control].hasError(error);
  }

  save() {
    // this.fillMedicines();
    // this.fillInstructions();

    this.repository.post('checkings', this.checkingForm.value).subscribe(
      (res: any) => {
        // this.router.navigate([`/home/patient/profile/${this.route.snapshot.params.id}`], { state: { tabindex: 0 } });
      },
      (err: any) => {
        this.snackBar.open(err.error, '', {
          duration: 1000,
          panelClass: ['red-snackbar']
        });
      });

  }

}
