import { autoinject, bindable, bindingMode } from 'aurelia-framework';
import { Notifier } from "services/notifier";
import { GroupRepository } from 'repositories/groupRepository';
import { EntityResult } from 'models/entityResult';
import { GroupRead } from 'models/groupRead';
import { EntityQuery } from 'models/entityQuery';

@autoinject
export class GroupList {
  @bindable loading: boolean = false;
  @bindable searchText: string;

  @bindable({ defaultBindingMode: bindingMode.twoWay }) page: number;
  @bindable({ defaultBindingMode: bindingMode.twoWay }) pageSize: number;

  result: EntityResult<GroupRead>;
  query: EntityQuery;

  constructor(
    private notifier: Notifier,
    private groupRepository: GroupRepository) {

    this.page = 1;
    this.pageSize = 20;

    this.query = {
      page: this.page,
      pageSize: this.pageSize,
      sort: [
        { name: 'Sequence' },
        { name: 'Name' }
      ]
    };
  }

  async attached() {
    await this.load();
  }

  async pageChanged(newValue, oldValue) {
    if (newValue === oldValue) {
      return;
    }

    this.query.page = newValue;
    await this.load();
  }

  async pageSizeChanged(newValue, oldValue) {
    if (newValue === oldValue) {
      return;
    }

    this.query.pageSize = newValue;
    await this.load();
  }

  async search() {
    if (!this.searchText) {
      this.query.filter = null;
      await this.load();
      return;
    }

    this.query.filter = {
      logic: 'or',
      filters: [{
        name: 'Name',
        value: this.searchText,
        operator: 'Contains'
      }, {
        name: 'Description',
        value: this.searchText,
        operator: 'Contains'
      }]
    };

    await this.load();
  }

  async sort() {
    await this.load();
  }

  async load() {
    this.loading = true;
    try {
      this.result = await this.groupRepository.query(this.query);
    } catch (e) {
      await this.notifier.error(e);
    } finally {
      this.loading = false;
    }
  }
}
