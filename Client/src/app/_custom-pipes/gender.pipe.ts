import { GenderEnum } from './../_enums/gender.enum';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'gender'
})
export class GenderPipe implements PipeTransform {

  transform(val: string): string {
    if (val === GenderEnum[GenderEnum.female]) {
      return 'انثى';
    } else if (val === GenderEnum[GenderEnum.male]) {
      return 'ذكر';
    }
    return '';
  }

}
