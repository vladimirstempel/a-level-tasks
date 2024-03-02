import apiClient from "../client";
import { Credentials } from '../../interfaces/credentials'
import { AuthResponse } from '../../interfaces/auth-response'

export const login = (credentials: Credentials) => apiClient<AuthResponse>({
  path: `login`,
  method: 'POST',
  data: credentials
})

export const registration = (credentials: Credentials) => apiClient<AuthResponse>({
  path: `register`,
  method: 'POST',
  data: credentials
})