import React, { ReactElement, FC, useEffect, useState } from 'react'
import {
  CircularProgress,
  Container, Fab,
  Grid,
} from '@mui/material'
import { IResource } from '../../interfaces/resource'
import { useParams } from 'react-router-dom'
import { getById, update } from '../../api/modules/resource'
import '@styles/resource/Resource.scss'
import ResourceCard from '../Resources/components'
import ResourceUpdateDialog from './components'
import EditIcon from '@mui/icons-material/Edit'

const Resource: FC<unknown> = (): ReactElement => {
  const [resource, setResource] = useState<IResource | null>(null)
  const [isLoading, setIsLoading] = useState<boolean>(false)
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false)
  const { id } = useParams()

  useEffect(() => {
    if (id) {
      const getResource = async () => {
        try {
          setIsLoading(true)
          const res = await getById(id)
          setResource({
            ...res.data,
            year: new Date(res.data.year, 0)
          })
        } catch (e) {
          if (e instanceof Error) {
            console.error(e.message)
          }
        }
        setIsLoading(false)
      }
      getResource()
    }
  }, [id])

  const openModal = () => {
    setIsModalOpen(true)
  }

  const onModalClosed = async (formData: IResource | null) => {
    if (formData) {
      const data = await update({
        ...formData,
        year: formData.year.getFullYear()
      })
      setResource((prevState) => ({
        ...prevState,
        ...data,
        year: formData.year
      }))
    }
    setIsModalOpen(false)
  }

  return (
    <Container className='resource'>
      <Grid container spacing={ 4 } justifyContent="center" m={ 4 }>
        { isLoading ? (
          <CircularProgress/>
        ) : resource ? (
          <>
            <ResourceCard { ...resource } />
            <Fab className='modal-open-button' color="primary" aria-label="add" onClick={openModal}>
              <EditIcon/>
            </Fab>
            <ResourceUpdateDialog open={isModalOpen} onClose={onModalClosed} providedResource={resource} />
          </>
        ) : <></> }
      </Grid>
    </Container>
  )
}

export default Resource