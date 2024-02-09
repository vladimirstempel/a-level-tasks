import React, { ReactElement, FC, useEffect, useState } from 'react'
import {
  Card,
  CardContent,
  CircularProgress,
  Container,
  Grid,
  Typography
} from '@mui/material'
import { IResource } from '../../interfaces/resource'
import { useParams } from 'react-router-dom'
import { getById } from '../../api/modules/users'
import '@styles/resource/Resource.scss'

const Resource: FC<any> = (): ReactElement => {
  const [resource, setResource] = useState<IResource | null>(null)
  const [isLoading, setIsLoading] = useState<boolean>(false)
  const { id } = useParams()

  useEffect(() => {
    if (id) {
      const getResource = async () => {
        try {
          setIsLoading(true)
          const res = await getById(id)
          setResource(res.data)
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

  return (
    <Container className='resource'>
      <Grid container spacing={ 4 } justifyContent="center" m={ 4 }>
        { isLoading ? (
          <CircularProgress/>
        ) : (
          <>
            <Card sx={ { maxWidth: 250 } }>
              <div className='resource__color' style={{ backgroundColor: resource?.color }}></div>
              <CardContent>
                <Typography noWrap gutterBottom variant="h6" component="div">
                  { resource?.name }
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  { resource?.pantone_value }
                </Typography>
              </CardContent>
            </Card>
          </>
        ) }
      </Grid>
    </Container>
  )
}

export default Resource