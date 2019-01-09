import * as moment from 'moment'

export class DateFormatValueConverter {
  fromView(date: string, viewFormat: string) {
    return date != null ? moment(date).format(viewFormat) : null;
  }
  toView(date: string, viewFormat: string) {
    return date != null ? moment(date).format(viewFormat) : null;
  }
}
