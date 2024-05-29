/**
 * This class use Singleton pattern, please use the method getInstance
 */
export class GlobalSettings {

  private static instance: GlobalSettings;

  public static token: string = '';
  public static userName: string = '';
  public static userEmail: string = '';

  private constructor() {}

  /**
   * Get the singleton instance of GlobalSettings.
   * @returns The singleton instance of GlobalSettings.
   */
  public static getInstance(): GlobalSettings {

    if (!GlobalSettings.instance) {
      GlobalSettings.instance = new GlobalSettings();
    }

    return GlobalSettings.instance;
  }

  /**
   * Initialize global settings with provided values.
   * @param token The authentication token.
   * @param userName The username.
   * @param userEmail The user's email.
   */
  public static initialize(token: string, userName: string, userEmail: string): void {
    GlobalSettings.token = token;
    GlobalSettings.userName = userName;
    GlobalSettings.userEmail = userEmail;
  }
}
