export class Pagination {
  #dataType = 'users'

  currentPage = 1
  per_page = 6

  constructor(totalPages, renderer, dataType) {
    this.totalPages = totalPages
    this.renderer = renderer
    this.#dataType = dataType
  }
  
  renderPagination() {
    const paginationElement = document.querySelector('.pagination')
    const paginationItems = []

    paginationElement.innerHTML = ''

    const prevListItem = this.createPageItem(-1, this.totalPages)
    paginationItems.push(prevListItem)

    for (let i = 1; i <= this.totalPages; i++) {
      const listItem = this.createPageItem(i, this.totalPages)

      if (i === 1) {
        listItem.classList.add('active')
      }

      paginationItems.push(listItem)
    }

    const nextListItem = this.createPageItem(0, this.totalPages)
    paginationItems.push(nextListItem)

    paginationItems.forEach(item => paginationElement.append(item))
  }

  async changePage(page) {
    if (page === -1 && this.currentPage > 1) {
      this.currentPage = this.currentPage - 1
      await this.renderer(this.currentPage, this.#dataType)
    }
    if (page === 0 && this.currentPage < this.totalPages) {
      this.currentPage = this.currentPage + 1
      await this.renderer(this.currentPage, this.#dataType)
    }
    if (page > 0) {
      this.currentPage = page
      await this.renderer(this.currentPage, this.#dataType)
    }

    this.handleActiveClass()
    this.handlePrevNextDisable()
  }

  createPageItem(page) {
    const listItem = document.createElement('li')
    listItem.classList.add('page-item')

    const button = document.createElement('button')
    button.classList.add('page-link')
    button.onclick = () => this.changePage(page, listItem, this.totalPages)
    button.innerHTML = '<span aria-hidden="true">&laquo;</span>'

    if (page === -1) {
      listItem.classList.add('page-prev', 'disabled')
      listItem.ariaLabel = 'Previous'
      button.innerHTML = '<span aria-hidden="true">&laquo;</span>'
    } else if (page === 0) {
      listItem.classList.add('page-next')
      listItem.ariaLabel = 'Next'
      button.innerHTML = '<span aria-hidden="true">&raquo;</span>'
    } else {
      listItem.classList.add('page-specific')
      listItem.dataset.page = page
      button.innerHTML = page.toString()
    }

    listItem.append(button)

    return listItem
  }

  handleActiveClass() {
    const paginationItems = document.querySelectorAll('.page-item.page-specific')

    Array.from(paginationItems)
      .forEach(item => {
        item.classList.remove('active')

        if (item.dataset.page === this.currentPage.toString()) {
          item.classList.add('active')
        }
      })
  }
  handlePrevNextDisable() {
    const paginationItems = document.querySelectorAll('.page-item:not(.page-specific)')

    Array.from(paginationItems)
      .forEach(item => {
        if (item.classList.contains('page-next')) {
          this.currentPage === this.totalPages
            ? item.classList.add('disabled')
            : item.classList.remove('disabled')
        }
        if (item.classList.contains('page-prev')) {
          this.currentPage === 1
            ? item.classList.add('disabled')
            : item.classList.remove('disabled')
        }
      })
  }
}