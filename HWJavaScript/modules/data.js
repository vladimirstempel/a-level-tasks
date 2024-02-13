import { ApiService } from "../services/api-service.js";
import { NotificationService } from "../services/notification-service.js";

export class Data {
  #apiService = new ApiService()

  toastService = new NotificationService()

  async renderList(page = 1, dataType) {
    const dataList = document.querySelector('.data-list')
    const response = await this.#apiService.getData(dataType, {
      page,
      per_page: 6
    })

    dataList.innerHTML = ''
    response.data.forEach((item) => dataType === 'users'
      ? this.createUserCard(item, dataList)
      : this.createResourceCard(item, dataList))

    return response
  }

  addRecord(data, dataType, options = {}) {
    return this.#apiService.addData(dataType, data, options)
      .then(() => this.renderList(1, dataType))
  }

  createUserCard(entity, container) {
    const columnElement = document.createElement('div')
    columnElement.classList.add('col')

    const userElement = document.createElement('div')
    userElement.classList.add('card')
    userElement.dataset.id = entity.id

    const imageElement = document.createElement('img')
    imageElement.classList.add('card-img-top')
    imageElement.src = entity.avatar
    imageElement.alt = `${entity.first_name} ${entity.last_name}`

    const cardBodyElement = document.createElement('div')
    cardBodyElement.classList.add('card-body')

    const titleElement = document.createElement('h5')
    titleElement.classList.add('card-title')
    titleElement.innerText = `${entity.first_name} ${entity.last_name}`

    const descriptionElement = document.createElement('p')
    descriptionElement.classList.add('card-text')
    descriptionElement.innerText = entity.email

    const detailsLinkElement = document.createElement('a')
    detailsLinkElement.classList.add('btn', 'btn-primary')
    detailsLinkElement.href = '#'
    detailsLinkElement.innerText = 'Go somewhere'

    cardBodyElement.append(titleElement)
    cardBodyElement.append(descriptionElement)
    cardBodyElement.append(detailsLinkElement)

    userElement.append(imageElement)
    userElement.append(cardBodyElement)

    columnElement.append(userElement)

    container.appendChild(columnElement)
  }

  createResourceCard(entity, container) {
    const columnElement = document.createElement('div')
    columnElement.classList.add('col')

    const userElement = document.createElement('div')
    userElement.classList.add('card')
    userElement.dataset.id = entity.id

    const imageElement = document.createElement('svg')
    imageElement.classList.add('bd-placeholder-img', 'card-img-top')
    imageElement.style.backgroundColor = entity.color
    imageElement.style.width = '100%'
    imageElement.style.height = '180px'
    imageElement.innerHTML = `
      <rect width="100%" height="100%" fill="#868e96"></rect>
    `

    const cardBodyElement = document.createElement('div')
    cardBodyElement.classList.add('card-body')

    const titleElement = document.createElement('h5')
    titleElement.classList.add('card-title')
    titleElement.innerText = `${entity.name}`

    const descriptionElement = document.createElement('p')
    descriptionElement.classList.add('card-text')
    descriptionElement.innerHTML = `
      Pantone: ${entity.pantone_value}<br>
      Year: ${entity.year}<br>
      Color: ${entity.color}
    `

    const detailsLinkElement = document.createElement('a')
    detailsLinkElement.classList.add('btn', 'btn-primary')
    detailsLinkElement.href = '#'
    detailsLinkElement.innerText = 'Go somewhere'

    cardBodyElement.append(titleElement)
    cardBodyElement.append(descriptionElement)
    cardBodyElement.append(detailsLinkElement)

    userElement.append(imageElement)
    userElement.append(cardBodyElement)

    columnElement.append(userElement)

    container.appendChild(columnElement)
  }
}