import * as nprogress from 'nprogress';
import { Interceptor } from 'aurelia-fetch-client';

export class LoadingInterceptor implements Interceptor {
  request(request: Request): Request {
    nprogress.start();
    return request;
  }

  response(response: Response): Response  {
    nprogress.done();
    return response;
  }

  responseError(error: any, request?: Request): Promise<Response> {
    nprogress.done();
    return Promise.reject(error);
  }
}
