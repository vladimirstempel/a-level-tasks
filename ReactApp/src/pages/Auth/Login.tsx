import React, { FC, ReactElement, useContext } from 'react'
import { Box, Button, Card, CardActions, CardContent, CardHeader, TextField } from '@mui/material'
import { useNavigate } from 'react-router-dom'
import { useForm } from 'react-hook-form'
import { yupResolver } from '@hookform/resolvers/yup'
import { Credentials } from '../../interfaces/credentials'
import { loginValidationSchema } from '../../shared/validations'
import { registration } from '../../api/modules/auth'
import { observer } from 'mobx-react'
import { AuthContext } from '../../index'

const Login: FC<unknown> = (): ReactElement => {
  const navigate = useNavigate()
  const auth = useContext(AuthContext)

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    resolver: yupResolver<Credentials>(loginValidationSchema)
  })

  const submit = async (credentials: Credentials) => {
    const response = await registration(credentials)
    reset()
    if (response) {
      auth.setToken(response.token)
      navigate('/')
    }
  }

  return (<Card sx={{ mx: 'auto', my: 4, maxWidth: 500 }}>
      <CardHeader title="Login" />
      <CardContent>
        <Box component="form">
          <TextField
            autoFocus
            required
            margin="normal"
            id="email"
            label="Email"
            type="email"
            fullWidth
            { ...register('email') }
            error={ !!errors.email }
            helperText={ errors.email?.message }
          />
          <TextField
            required
            margin="normal"
            label="Password"
            type="password"
            fullWidth
            { ...register('password') }
            error={ !!errors.password }
            helperText={ errors.password?.message }
          />
        </Box>
      </CardContent>
      <CardActions>
        <Button type="submit" color="primary" onClick={handleSubmit(submit)}>Submit</Button>
      </CardActions>
    </Card>
  )
}

export default observer(Login)