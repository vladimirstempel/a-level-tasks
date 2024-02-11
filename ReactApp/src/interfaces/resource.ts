export interface IResource {
  id?: number,
  name: string,
  year: Date,
  color: string,
  pantone_value: string
}

export type IResourceData = {
  [P in keyof IResource]: IResource[P] extends Date ? number : IResource[P]
}