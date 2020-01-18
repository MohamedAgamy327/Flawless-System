import { Pipe, PipeTransform } from '@angular/core';
import { RoleEnum } from '../_enums/role.enum';

@Pipe({
  name: 'role'
})
export class RolePipe implements PipeTransform {

  transform(val: string): string {
    if (val === RoleEnum[RoleEnum.Doctor]) {
      return 'دكتور';
    } else if (val === RoleEnum[RoleEnum.Nurse]) {
      return 'ممرضه';
    }
    return '';
  }

}
