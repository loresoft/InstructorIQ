export class EntityFilter {
  name?: string;
  operator?: string;
  value?: string | number | Date;
  logic?: string;
  filters?: EntityFilter[]
}
