import { HttpClient } from 'aurelia-fetch-client';
import { AureliaConfiguration } from "aurelia-configuration";
import { LoadingInterceptor } from 'services/loadingInterceptor';
import { TokenInterceptor } from './tokenInterceptor';
import { autoinject } from 'aurelia-framework';

@autoinject
export class Network extends HttpClient {

  constructor(
    private configuration: AureliaConfiguration,
    private tokenInterceptor: TokenInterceptor,
    private loadingInterceptor: LoadingInterceptor
  ) {
    super();
   
    const endpoint = configuration.get('Hosting.ServiceEndpoint', '/api/');

    this.configure(config => {
      config
        .useStandardConfiguration()
        .withBaseUrl(endpoint)
        .withDefaults({
          credentials: 'same-origin',
          headers: {
            'Accept': 'application/json',
            'X-Requested-With': 'Fetch'
          }
        })
        .withInterceptor(this.loadingInterceptor)
        .withInterceptor(this.tokenInterceptor)
    });
  }
}
