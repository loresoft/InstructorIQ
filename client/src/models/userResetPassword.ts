
export interface IUserResetPassword {
  emailAddress?: string;
  securityToken?: string;
  updatedPassword?: string;
}

export class UserResetPassword implements IUserResetPassword {
  emailAddress?: string;
  securityToken?: string;
  updatedPassword?: string;
}

