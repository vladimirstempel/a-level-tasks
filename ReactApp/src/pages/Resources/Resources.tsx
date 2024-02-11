import React, { ReactElement, FC, useEffect, useState } from 'react'
import { Box, CircularProgress, Container, Fab, Grid, Pagination } from '@mui/material'
import ResourceCard from './components'
import { create, getByPage } from '../../api/modules/resource'
import { IResource } from '../../interfaces/resource'
import '@styles/App.scss'
import AddIcon from '@mui/icons-material/Add'
import ResourceCreateDialog from './components/ResourceCreateDialog'

const Resources: FC<unknown> = (): ReactElement => {
  const [resources, setResources] = useState<IResource[] | null>(null)
  const [totalPages, setTotalPages] = useState<number>(0)
  const [currentPage, setCurrentPage] = useState<number>(1)
  const [isLoading, setIsLoading] = useState<boolean>(false)
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false)

  useEffect(() => {
    const getResource = async () => {
      try {
        setIsLoading(true)
        const res = await getByPage(currentPage)
        setResources([
          ...res.data
            .map(item => ({
              ...item,
              year: new Date(item.year, 0)
            })),
        ])
        setTotalPages(res.total_pages)
      } catch (e) {
        if (e instanceof Error) {
          console.error(e.message)
        }
      }
      setIsLoading(false)
    }
    getResource()
  }, [currentPage])

  const openModal = () => {
    setIsModalOpen(true)
  }

  const onModalClosed = async (formData: IResource | null) => {
    setIsModalOpen(false)

    if (formData) {
      await create({
        ...formData,
        year: formData.year.getFullYear()
      })
    }
  }

  return (
    <Container>
      <Grid container spacing={ 4 } justifyContent="center" my={ 4 }>
        { isLoading ? (
          <CircularProgress/>
        ) : (
          <>
            { resources?.map((item) => (
              <Grid key={ item.id } item lg={ 4 } md={ 3 } xs={ 2 }>
                <ResourceCard { ...item } />
              </Grid>
            )) }
          </>
        ) }
      </Grid>
      <Box
        sx={ {
          display: 'flex',
          justifyContent: 'center'
        } }
      >
        <Pagination sx={ { mb: 4 } } count={ totalPages } page={ currentPage }
                    onChange={ (event, page) => setCurrentPage(page) }/>
      </Box>
      <Fab className='modal-open-button' color="primary" aria-label="add" onClick={openModal}>
        <AddIcon/>
      </Fab>
      <ResourceCreateDialog open={isModalOpen} onClose={onModalClosed} />
    </Container>
  )
}

export default Resources