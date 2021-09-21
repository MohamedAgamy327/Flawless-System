import { Component, Input } from '@angular/core';
import { Patient } from 'src/app/_models';

@Component({
  selector: 'app-patient-information',
  templateUrl: './patient-information.component.html',
  styleUrls: ['./patient-information.component.css']
})
export class PatientInformationComponent  {

  @Input() public patient: Patient;

  constructor() { }


}
