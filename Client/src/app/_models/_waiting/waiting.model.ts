export interface Waiting {
  id: number;
  arrivalDate: Date;
  canceledDate: Date;
  enteredDate: Date;
  finishedDate: Date;
  order: number;
  patientId: number;
  patientName: string;
  patientTelephone: string;
}

