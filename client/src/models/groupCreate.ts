import { EntityCreate } from "./entityCreate";

export interface GroupCreate extends EntityCreate {
  name?: string;
  description?: string;
  sequence?: number;
}
