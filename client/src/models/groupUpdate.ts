import { EntityUpdate } from "./entityUpdate";

export interface GroupUpdate extends EntityUpdate {
  name?: string;
  description?: string;
  sequence?: number;
}
