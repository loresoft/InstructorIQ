import { UserProfile } from 'models/userProfile';
import { Network } from "services/network";
import { json } from 'aurelia-fetch-client';
import { Operation } from 'fast-json-patch';
import { autoinject } from 'aurelia-framework';
import { UserRegister } from 'models/userRegister';

@autoinject
export class UserRepository {
  private endpoint = 'user/';

  constructor(
    private network: Network
  ) {
    
  }

  async register(registration: UserRegister) : Promise<UserProfile> {
    const url = `${this.endpoint}register`;
    
    const results = await this.network.post(url, json(registration));
    const o = results.json();

    return o as UserProfile;
  }

  async updateProfile(userId: string, profile: UserProfile) : Promise<UserProfile> {
    const url = `${this.endpoint}${userId}`;
    
    const results = await this.network.put(url, json(profile));
    const o = results.json();

    return o as UserProfile;
  }

  async patchProfile(userId: string, operations: Operation[]) : Promise<UserProfile> {
    const url = `${this.endpoint}${userId}`;
    
    const results = await this.network.patch(url, json(operations));
    const o = results.json();

    return o as UserProfile;
  }

  async changePassword(userId: string, currentPassword: string, updatedPassword: string){
    const url = `${this.endpoint}${userId}/changePassword`;
    const model = {currentPassword, updatedPassword};

    const results = await this.network.put(url, json(model));
    const o = results.json();

    return o as UserProfile;
  }
}
