import { GenderEnum } from './../_enums/gender.enum';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'gender'
})
export class GenderPipe implements PipeTransform {

  transform(val: string): string {
    if (val === GenderEnum[GenderEnum.Female]) {
      return 'انثى';
    } else if (val === GenderEnum[GenderEnum.Male]) {
      return 'ذكر';
    }
    return '';
  }

}
