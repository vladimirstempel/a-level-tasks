import apiClient from "../client";
import { IResource } from '../../interfaces/resource'

export const getById = (id: string) => apiClient({
  path: `resource/${id}`,
  method: 'GET'
})

export const getByPage = (page: number) => apiClient({
  path: `resource?page=${page}`,
  method: 'GET'
})

export const create = (resource: IResource) => apiClient({
  path: `resource`,
  method: 'POST',
  data: resource
})

export const update = (resource: IResource) => apiClient({
  path: `resource`,
  method: 'PUT',
  data: resource
})
