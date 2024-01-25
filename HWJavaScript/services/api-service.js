import { HttpClient } from "../core/http-client.js";

export class ApiService {
  #http = new HttpClient()
  #apiUrl = 'https://reqres.in/api'

  getData(dataType, params = {}) {
    return this.#http.get(`${this.#apiUrl}/${dataType}`, {
      queryParams: params
    }).then(response => response.json())
  }

  addData(dataType, data, options = {}) {
    return this.#http.post(`${this.#apiUrl}/${dataType}`, data, options)
  }
}