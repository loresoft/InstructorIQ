import { EntityFilter } from "./entityFilter";
import { EntitySort } from "./entitySort";

export class EntityQuery {
  query?: string;
  page?: number;
  pageSize?: number
  sort?: EntitySort[];
  filter?: EntityFilter;
}
