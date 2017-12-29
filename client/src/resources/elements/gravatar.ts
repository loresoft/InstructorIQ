import {computedFrom, bindable, inject} from 'aurelia-framework';
import md5 from 'md5';

export class GravatarCustomElement {

  @bindable email = '';
  @bindable size = 200;
  @bindable rating = 'g';
  @bindable default = 'mm';
  @bindable secure = true;

  constructor() {
  }

  @computedFrom('size', 'email')
  get url() {
    let base = (this.secure ? 'https://secure' : 'http://www') + '.gravatar.com/avatar';
    let hash = this.email ? md5(this.email) : '';
    let url  = `${base}/${hash}/?s=${this.size}&d=${this.default}&r=${this.rating}`;

    return url;
  }
}
