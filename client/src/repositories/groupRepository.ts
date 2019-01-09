import { autoinject } from 'aurelia-framework';
import { Network } from 'services/network';
import { GroupCreate } from 'models/groupCreate';
import { GroupRead } from 'models/groupRead';
import { GroupUpdate } from 'models/groupUpdate';
import { Repository } from './repository';

@autoinject
export class GroupRepository extends Repository<GroupRead, GroupCreate, GroupUpdate> {

  constructor(
    network: Network
  ) {
    super(network, 'group/');
  }

}
