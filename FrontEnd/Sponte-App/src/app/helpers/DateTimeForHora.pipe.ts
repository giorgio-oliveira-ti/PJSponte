import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';
import { ConstatsDataHora } from '@app/Util/ConstatsDataHora';


@Pipe({
  name: 'DateTime'
})
export class DateTimeForHoraPipe  extends DatePipe implements PipeTransform{

  override transform(value: any, args?: any): any {
    return super.transform(value, ConstatsDataHora.DATE_TIME2);
  }

}
