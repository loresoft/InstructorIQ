
export interface ITokenError {
  error?: string;
  error_description?: string;
}

export class TokenError implements ITokenError {
  error?: string;
  error_description?: string;
}

