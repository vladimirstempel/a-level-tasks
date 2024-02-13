export class NotificationService {
  #toast = document.querySelector('.toast')

  success() {
    const toast = bootstrap.Toast.getOrCreateInstance(this.#toast)

    toast.show()
  }
}