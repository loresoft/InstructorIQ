import { autoinject, bindable } from 'aurelia-framework';
import { EventAggregator } from 'aurelia-event-aggregator';
import { BindingSignaler } from 'aurelia-templating-resources';
import { HttpClient } from 'aurelia-fetch-client';
import { AureliaConfiguration } from "aurelia-configuration";

import jwtDecode from 'jwt-decode';

import { logger } from "services/logger";
import { TokenResponse, ITokenResponse } from 'models/tokenResponse';
import { TokenResult } from 'models/tokenResult';
import { LoadingInterceptor } from 'services/loadingInterceptor';

@autoinject
export class Authentication {
  tokenKey: string = "iq-token"

  @bindable authenticated: boolean = false;
  @bindable name: string;
  @bindable email: string;

  @bindable userId: string;

  @bindable organizationId: string;
  @bindable organizationName: string;


  initialUrl: string = "/";

  private http: HttpClient;
  private clientId: string;
  private tokenEndpoint: string;

  private token: ITokenResponse = null;
  private payload: any = null;
  private expiration: number = null;

  constructor(
    private eventAggregator: EventAggregator,
    private bindingSignaler: BindingSignaler,
    private configuration: AureliaConfiguration,
    private loadingInterceptor: LoadingInterceptor
  ) {

    this.http = new HttpClient();
    this.http.configure(config => {
      config
        .withDefaults({
          credentials: 'same-origin',
          headers: {
            'Accept': 'application/json',
            'X-Requested-With': 'Fetch'
          }
        })
        .withInterceptor(this.loadingInterceptor)
    });

    this.clientId = configuration.get("Authentication.ClientId", "InstructorIQ");
    this.tokenEndpoint = configuration.get("Authentication.TokenEndpoint", "/api/token");

    this.loadToken();
  }

  async login(email: string, password: string, organizationId?: string): Promise<TokenResult> {
    let formData = new URLSearchParams();
    formData.append("grant_type", "password");
    formData.append("client_id", this.clientId);
    formData.append("username", email);
    formData.append("password", password);

    if (organizationId)
      formData.append("organization_id", organizationId);

    let result = await this.fetchToken(formData);

    return result;
  }

  logout(): void {
    this.clearToken();
  }

  isAuthenticated(): boolean {
    return !!this.token && !this.isTokenExpired();
  }

  isTokenExpired(): boolean {
    let time = Math.round(new Date().getTime() / 1000);
    return time >= this.expiration;
  }

  async checkToken(): Promise<boolean> {
    logger.debug("checkToken()");
    
    if (this.isAuthenticated())
      return true;

    if (!this.token)
      return false;

    if (this.isTokenExpired())
      await this.refreshToken();

    return this.isAuthenticated();
  }

  async refreshToken(organizationId?: string): Promise<TokenResult> {
    if (!this.token || !this.token.refresh_token)
      return {
        successful: false,
        message: "Refresh token not supported."
      };;

    let formData = new URLSearchParams();
    formData.append("grant_type", "refresh_token");
    formData.append("client_id", this.clientId);
    formData.append("refresh_token", this.token.refresh_token);

    if (organizationId)
      formData.append("organization_id", organizationId);

    let result = await this.fetchToken(formData);
    return result;
  }

  async fetchToken(formData: URLSearchParams): Promise<TokenResult> {
    try {
      let response = await this.http.fetch(this.tokenEndpoint, {
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
        },
        method: 'POST',
        body: formData
      })

      let o = await response.json();

      if (response.ok) {
        logger.info("fetch token successful: ", o);

        this.setToken(o);
        return {
          successful: true
        };
      }

      logger.error("fetch token failed: ", o);

      let m = o.error_description
        ? o.error_description
        : "Unknown Server Error";

      return {
        successful: false,
        message: m
      };
    } catch (e) {
      logger.error(`fetch token error: ${e}`, e);

      return {
        successful: false,
        message: "Unknown Server Error"
      };
    }
  }

  loadToken() {
    let token = this.getToken();
    if (!token)
      return;

    this.processToken(token);
  }

  processToken(token: ITokenResponse) {
    logger.debug("Update Token", token);
    this.token = token;

    if (this.token && this.token.access_token) {
      try {
        this.payload = jwtDecode(this.token.access_token);
      } catch (_) { }
    }

    if (this.payload) {
      this.expiration = this.payload.exp;
      this.name = this.payload.name;
      this.email = this.payload.email;
      this.userId = this.payload.uid;
      this.organizationId = this.payload.oid;
      this.organizationName = this.payload.org;
    } else {
      this.expiration = null;
      this.name = null
      this.email = null;
      this.userId = null;
      this.organizationId = null;
      this.organizationName = null;
    }

    let isAuthenticated = this.isAuthenticated();
    this.updateAuthenticated(isAuthenticated);    
  }

  updateAuthenticated(authenticated: boolean){
    let wasAuthenticated = this.authenticated;
    this.authenticated = authenticated;

    if (wasAuthenticated !== this.authenticated) {
      this.bindingSignaler.signal('authentication-change');
      this.eventAggregator.publish('authentication-change', this.authenticated);

      logger.info(`Authorization changed to: ${this.authenticated}`);
    }
  }

  setToken(token: ITokenResponse) {
    this.processToken(token);

    let json = JSON.stringify(token);
    localStorage.setItem(this.tokenKey, json);
  }

  getToken(): ITokenResponse {
    let json = localStorage.getItem(this.tokenKey);
    if (!json)
      return null;

    let token = JSON.parse(json);
    return token;
  }

  clearToken() {
    this.token = null;
    this.payload = null;
    this.expiration = null;
    this.name = null
    this.email = null;
    this.userId = null;
    this.organizationId = null;
    this.organizationName = null;

    this.updateAuthenticated(false);    

    localStorage.removeItem(this.tokenKey);
  }
}
