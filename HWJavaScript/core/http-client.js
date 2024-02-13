export class HttpClient {
  #headers = new Headers({
    'content-type': 'application/json'
  })

  get(url, options = {}) {
    if ('queryParams' in options) {
      url += this.#parseParams(options.queryParams)
    }
    return fetch(url, {
      headers: this.#headers,
      ...options,
      method: 'GET',
    })
  }

  post(url, body = {}, options = {}) {
    if ('queryParams' in options) {
      url += `${url}${this.#parseParams(options.queryParams)}`
    }
    return fetch(url, {
      headers: this.#headers,
      ...options,
      method: 'POST',
      body: JSON.stringify(body),
    })
  }

  put(url, body = {}, options = {}) {
    if ('queryParams' in options) {
      url += `${url}${this.#parseParams(options.queryParams)}`
    }
    return fetch(url, {
      headers: this.#headers,
      ...options,
      method: 'PUT',
      body: JSON.stringify(body),
    })
  }

  patch(url, body = {}, options = {}) {
    if ('queryParams' in options) {
      url += `${url}${this.#parseParams(options.queryParams)}`
    }
    return fetch(url, {
      headers: this.#headers,
      ...options,
      method: 'PATCH',
      body: JSON.stringify(body),
    })
  }

  delete(url, options = {}) {
    if ('queryParams' in options) {
      url += `${url}${this.#parseParams(options.queryParams)}`
    }
    return fetch(url, {
      headers: this.#headers,
      ...options,
      method: 'DELETE',
    })
  }

  #parseParams(params = {}) {
    return Object.keys(params).length ? `?${new URLSearchParams(params)}` : ''
  }
}