export interface IApiResponse<T> {
  data: T,
  support: {
    url: string,
    text: string
  }
}

export interface IApiResponsePages<T> extends IApiResponse<T> {
  page: number,
  per_page: number,
  total: number,
  total_pages: number,
}