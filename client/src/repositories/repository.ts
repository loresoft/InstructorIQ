import { queryString } from 'query-string';
import { Network } from "services/network";
import { json } from "aurelia-fetch-client";
import { Operation } from "fast-json-patch";
import { EntityResult } from "models/entityResult";
import { EntityQuery } from 'models/entityQuery';

export class Repository<TRead, TCreate, TUpdate> {
  endpoint = '';
  network: Network;

  constructor(
    network: Network,
    endpoint: string
  ) {
    this.network = network;
    this.endpoint = endpoint;
  }

  async create(create: TCreate): Promise<TRead>{
    const url = `${this.endpoint}`;
    
    const response = await this.network.post(url, json(create));
    const result = response.json();

    return result;
  }

  async update(id: string, update: TUpdate): Promise<TRead>{
    const url = `${this.endpoint}/${id}`;
    
    const response = await this.network.put(url, json(update));
    const result = response.json();

    return result;
  }

  async patch(id: string, operations: Operation[]) : Promise<TRead> {
    const url = `${this.endpoint}/${id}`;
    
    const response = await this.network.patch(url, json(operations));
    const result = response.json();

    return result;
  }

  async read(id: string) : Promise<TRead> {
    const url = `${this.endpoint}/${id}`;
    
    const response = await this.network.get(url);
    const result = response.json();

    return result;
  }

  async list(q?: string, sort?: string, page?: number, size?: number) : Promise<EntityResult<TRead>>{
    const params = { q, sort, page, size };
    const query = queryString.stringify(params);
    const url = `${this.endpoint}?${query}`;

    const response = await this.network.get(url)
    const result = response.json();

    return result;
  }

  async query(query: EntityQuery) : Promise<EntityResult<TRead>>{
    const url = `${this.endpoint}/query`;

    const response = await this.network.post(url, json(query));
    const result = response.json();

    return result;
  }
}
