import { Interceptor } from 'aurelia-fetch-client';
import { AuthenticationService } from "services/authenticationService";
import { autoinject } from 'aurelia-framework';

@autoinject
export class TokenInterceptor implements Interceptor {
  constructor(
    private authentication: AuthenticationService) {
  }

  async request(request: Request): Promise<Request> {
    const accessToken = await this.authentication.accessToken();
    if (!accessToken) {
      return request;
    }

    const token = `Bearer ${accessToken}`;
    request.headers.set('Authorization', token);

    return request;
  }

  response(response: Response): Response  {
    return response;
  }

  responseError(error: any, request?: Request): Promise<Response> {
    return Promise.reject(error);
  }
}
