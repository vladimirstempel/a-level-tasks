import apiClient from "../client";
import { IResourceData } from '../../interfaces/resource'
import { IApiResponse, IApiResponsePages } from '../../interfaces/api-response'

export const getById = (id: string) => apiClient<IApiResponse<IResourceData>>({
  path: `resource/${id}`,
  method: 'GET'
})

export const getByPage = (page: number) => apiClient<IApiResponsePages<IResourceData[]>>({
  path: `resource?page=${page}`,
  method: 'GET'
})

export const create = (resource: IResourceData) => apiClient<IApiResponse<IResourceData>>({
  path: `resource`,
  method: 'POST',
  data: resource
})

export const update = (resource: IResourceData) => apiClient<IResourceData>({
  path: `resource/${resource.id}`,
  method: 'PUT',
  data: resource
})
