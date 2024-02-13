import { Pagination } from "../modules/pagination.js";
import { Data } from "../modules/data.js";

export class Users extends Data {
  #pagination
  #dataType = 'users'

  async start() {
    console.info('Users start...')

    const response = await this.renderList(1, this.#dataType)

    this.#pagination = new Pagination(response.total_pages, this.renderList.bind(this), this.#dataType)

    this.#pagination.renderPagination()
  }
  
  addUser(event) {
    event.preventDefault()
    const form = event.target

    if (!event.target.checkValidity()) {

      form.classList.add('was-validated')
      return
    }

    form.classList.remove('was-validated')

    const formData = new FormData(form)
    formData.set('avatar', 'https://random.imagecdn.app/300/300')

    const data = Object.fromEntries(formData.entries())

    this.addRecord(data, this.#dataType)
      .then(() => {
        this.toastService.success()
        form.reset()
      })
  }
}