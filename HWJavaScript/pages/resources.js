import { Pagination } from "../modules/pagination.js";
import { Data } from "../modules/data.js";

export class Resources extends Data {
  #pagination
  #dataType = 'resources'

  async start() {
    console.info('Resources start...')

    const response = await this.renderList(1, this.#dataType)

    this.#pagination = new Pagination(response.total_pages, this.renderList.bind(this), this.#dataType)

    this.#pagination.renderPagination()
  }

  addResource(event) {
    event.preventDefault()
    const form = event.target

    if (!event.target.checkValidity()) {

      form.classList.add('was-validated')
      return
    }

    form.classList.remove('was-validated')

    const formData = new FormData(form)

    const data = Object.fromEntries(formData.entries())

    this.addRecord(data, this.#dataType)
      .then(() => {
        this.toastService.success()
        form.reset()
      })
  }
}