import { action, makeObservable, observable } from 'mobx'
import { AuthService } from '../services/auth'

export class Auth {
  private readonly authService = new AuthService()

  token: string | null

  isLoggedIn: boolean

  constructor(token: string | null = null) {
    this.token = token || this.authService.getToken()
    this.isLoggedIn = !!this.token

    makeObservable(this, {
      setToken: action,
      logOut: action,
      isLoggedIn: observable,
      token: observable
    })
  }

  setToken(token: string) {
    this.authService.setToken(token)
    this.token = token
    this.isLoggedIn = true
  }

  logOut() {
    this.authService.logOut()
    this.token = null
    this.isLoggedIn = false
  }
}

export default Auth