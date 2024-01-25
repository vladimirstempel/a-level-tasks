import { Users } from './pages/users.js'

const app = new Users()

async function main() {
  await app.start()

  const form = document.querySelector('.add-user-form')
  form.onsubmit = app.addUser.bind(app)
}

await main()