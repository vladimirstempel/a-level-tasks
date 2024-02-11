import React, { ReactElement, FC, useEffect, useState } from 'react'
import {
  CircularProgress,
  Container, Fab,
  Grid,
} from '@mui/material'
import { IUser } from '../../interfaces/users'
import { useParams } from 'react-router-dom'
import UserCard from '../Home/components'
import { getById, update } from '../../api/modules/users'
import EditIcon from '@mui/icons-material/Edit'
import UserUpdateDialog from './components'

const User: FC<unknown> = (): ReactElement => {
  const [user, setUser] = useState<IUser | null>(null)
  const [isLoading, setIsLoading] = useState<boolean>(false)
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false)
  const { id } = useParams()

  useEffect(() => {
    if (id) {
      const getUser = async () => {
        try {
          setIsLoading(true)
          const res = await getById(id)
          setUser(res.data)
        } catch (e) {
          if (e instanceof Error) {
            console.error(e.message)
          }
        }
        setIsLoading(false)
      }
      getUser()
    }
  }, [id])

  const openModal = () => {
    setIsModalOpen(true)
  }

  const onModalClosed = async (formData: IUser | null) => {
    if (formData) {
      const data = await update(formData)
      setUser((prevState) => ({
        ...prevState,
        ...data
      }))
    }
    setIsModalOpen(false)
  }

  return (
    <Container>
      <Grid container spacing={ 4 } justifyContent="center" m={ 4 }>
        { isLoading ? (
          <CircularProgress/>
        ) : (user ?
          <>
            <UserCard { ...user } />
            <Fab className='modal-open-button' color="primary" aria-label="add" onClick={openModal}>
              <EditIcon/>
            </Fab>
            <UserUpdateDialog open={isModalOpen} onClose={onModalClosed} providedUser={user} />
          </>
          : <></>) }
      </Grid>
    </Container>
  )
}

export default User