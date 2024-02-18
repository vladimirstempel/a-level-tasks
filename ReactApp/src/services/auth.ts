export class AuthService {
  private readonly _tokenKey = 'token'

  setToken(token: string) {
    localStorage.setItem(this._tokenKey, token)
  }

  getToken() {
    return localStorage.getItem(this._tokenKey)
  }

  logOut() {
    return localStorage.removeItem(this._tokenKey)
  }
}