import { Resources } from './pages/resources.js'

const app = new Resources()

async function main() {
  await app.start()

  const form = document.querySelector('.add-resource-form')
  form.onsubmit = app.addResource.bind(app)
}

await main()