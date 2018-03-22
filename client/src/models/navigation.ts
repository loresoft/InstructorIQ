export interface INavigation {
  name: string;
  type: string;
  url?: string;
  icon?: string;
  children?: INavigation[];
}

export class Navigation implements INavigation {
  name: string;
  type: string;
  url?: string;
  icon?: string;
  children?: INavigation[];
}
