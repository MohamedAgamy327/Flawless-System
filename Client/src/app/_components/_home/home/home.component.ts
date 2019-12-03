import { Component } from '@angular/core';
import { CredentialService } from 'src/app/_services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(public credentialService: CredentialService) {

  }

  editProfile() {

  }

  logout() {
    this.credentialService.logout();
  }


}
