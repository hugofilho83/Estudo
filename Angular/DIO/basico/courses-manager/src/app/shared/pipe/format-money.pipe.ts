import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatMoney',
})
export class FormatMoneyPipe implements PipeTransform {
  transform(value: string) {
    return value.replace(',', '').replace('.', ',');
  }
}
