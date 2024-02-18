import React, { FC, ReactElement } from 'react'
import { Box, Button, Card, CardActions, CardContent, CardHeader, TextField } from '@mui/material'
import { useForm } from 'react-hook-form'
import { yupResolver } from '@hookform/resolvers/yup'
import { registrationValidationSchema } from '../../shared/validations'
import { registration } from '../../api/modules/auth'
import { RegistrationCredentials } from '../../interfaces/credentials'
import { useNavigate } from 'react-router-dom'

const Registration: FC<unknown> = (): ReactElement => {
  const navigate = useNavigate()

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    resolver: yupResolver<RegistrationCredentials>(registrationValidationSchema)
  })

  const submit = async (credentials: RegistrationCredentials) => {
    const response = await registration(credentials)
    reset()
    if (response) {
      navigate('/login')
    }
  }

  return (
    <Card sx={{ mx: 'auto', my: 4, maxWidth: 500 }}>
      <CardHeader title="Registration" />
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
          <TextField
            required
            margin="normal"
            label="Confirm password"
            type="password"
            fullWidth
            { ...register('confirmPassword') }
            error={ !!errors.confirmPassword }
            helperText={ errors.confirmPassword?.message }
          />
        </Box>
      </CardContent>
      <CardActions>
        <Button type="submit" color="primary" onClick={handleSubmit(submit)}>Submit</Button>
      </CardActions>
    </Card>
  )
}

export default Registration