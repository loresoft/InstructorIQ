
export interface ITokenResponse {
  access_token?: string;
  token_type?: string;
  expires_in: number;
  refresh_token?: string;
}

export class TokenResponse implements ITokenResponse {
  access_token?: string;
  token_type?: string;
  expires_in: number;
  refresh_token?: string;
}

