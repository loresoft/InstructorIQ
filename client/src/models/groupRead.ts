import { EntityRead } from "./entityRead";

export interface GroupRead extends EntityRead {
  name?: string;
  description?: string;
  sequence?: number;
  tenantId?: string;
  tenantName?: string;
}
