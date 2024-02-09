import { Card, CardActionArea, CardContent, Typography } from '@mui/material'
import React, { FC, ReactElement } from 'react'
import { useNavigate } from 'react-router-dom'
import { IResource } from '../../../interfaces/resource'
import '@styles/resource/Resource.scss'

const ResourceCard: FC<IResource> = (props): ReactElement => {
  const navigate = useNavigate()

  return (
    <Card sx={ { width: 300 } }>
      <CardActionArea onClick={ () => navigate(`/resource/${ props.id }`) }>
        <div className="resource__color" style={ { backgroundColor: props?.color } }></div>
        <CardContent>
          <Typography noWrap gutterBottom variant="h6" component="div">
            { props.name }
          </Typography>
          <Typography variant="body2" color="text.secondary">
            { props?.pantone_value }
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  )
}

export default ResourceCard