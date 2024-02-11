import React, { ReactElement, FC, useEffect, useState } from 'react'
import { Box, CircularProgress, Container, Fab, Grid, Pagination } from '@mui/material'
import { IUser } from '../../interfaces/users'
import UserCard from './components'
import { getByPage, create } from '../../api/modules/users'
import AddIcon from '@mui/icons-material/Add'
import UserCreateDialog from './components/UserCreateDialog'

const Home: FC<unknown> = (): ReactElement => {
  const [users, setUsers] = useState<IUser[] | null>(null)
  const [totalPages, setTotalPages] = useState<number>(0)
  const [currentPage, setCurrentPage] = useState<number>(1)
  const [isLoading, setIsLoading] = useState<boolean>(false)
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false)

  useEffect(() => {
    const getUser = async () => {
      try {
        setIsLoading(true)
        const res = await getByPage(currentPage)
        setUsers(res.data)
        setTotalPages(res.total_pages)
      } catch (e) {
        if (e instanceof Error) {
          console.error(e.message)
        }
      }
      setIsLoading(false)
    }
    getUser()
  }, [currentPage])

  const openModal = () => {
    setIsModalOpen(true)
  }

  const onModalClosed = async (formData: IUser | null) => {
    setIsModalOpen(false)

    if (formData) {
      await create(formData)
    }
  }

  return (
    <Container>
      <Grid container spacing={ 4 } justifyContent="center" my={ 4 }>
        { isLoading ? (
          <CircularProgress/>
        ) : (
          <>
            { users?.map((item) => (
              <Grid key={ item.id } item lg={ 4 } md={ 3 } xs={ 2 }>
                <UserCard { ...item } />
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
      <UserCreateDialog open={isModalOpen} onClose={onModalClosed} />
    </Container>
  )
}

export default Home