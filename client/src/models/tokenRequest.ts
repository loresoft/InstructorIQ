
export interface ITokenRequest {
  grant_type?: string;
  client_id?: string;
  user_name?: string;
  password?: string;
  refresh_token?: string;
  organization_id?: string;
}

export class TokenRequest implements ITokenRequest {
  grant_type?: string;
  client_id?: string;
  user_name?: string;
  password?: string;
  refresh_token?: string;
  organization_id?: string;
}

