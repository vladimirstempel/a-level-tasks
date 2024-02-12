import apiClient from "../client";
import { IUser } from '../../interfaces/users'
import { IApiResponse, IApiResponsePages } from '../../interfaces/api-response'

export const getById = (id: string) => apiClient<IApiResponse<IUser>>({
  path: `users/${id}`,
  method: 'GET'
})

export const getByPage = (page: number) => apiClient<IApiResponsePages<IUser[]>>({
  path: `users?page=${page}`,
  method: 'GET'
})

export const create = (user: IUser) => apiClient<IApiResponse<IUser>>({
  path: `users`,
  method: 'POST',
  data: user
})

export const update = (user: IUser) => apiClient<IUser>({
  path: `users/${user.id}`,
  method: 'PUT',
  data: user
})
