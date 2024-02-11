const baseUrl = "https://reqres.in/api/"

async function handleResponse<T>(response: Response): Promise<T> {
  if (!response.ok) {
    const message = await response.json()
    throw Error(message.error || 'Request error')
  }
  return response.json()
}

async function apiClient<T = unknown>({ path, method, data }: apiClientProps): Promise<T> {
  const requestOptions = {
    method,
    headers: { 'Content-Type': 'application/json' },
    body: data ? JSON.stringify(data) : undefined
  }
  return await fetch(`${baseUrl}${path}`, requestOptions).then(handleResponse<T>)
}

interface apiClientProps {
  path: string
  method: string
  data?: unknown
}

export default apiClient
