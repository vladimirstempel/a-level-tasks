import { FC, ReactElement } from 'react'
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  TextField
} from '@mui/material'
import '@styles/App.scss'
import { IUser } from '../../../interfaces/users'
import { useForm } from 'react-hook-form'
import { yupResolver } from '@hookform/resolvers/yup'
import { userValidationSchema } from '../../../shared/validations'


export interface UserCreateDialogProps {
  open: boolean;
  onClose: (value: IUser | null) => Promise<void>;
}

const UserCreateDialog: FC<UserCreateDialogProps> = (props: UserCreateDialogProps): ReactElement => {
  const { onClose, open } = props;

  const {
    register,
    handleSubmit,
    formState: { errors },
    getValues,
    reset
  } = useForm({
    resolver: yupResolver(userValidationSchema)
  })

  const handleClose = () => {
    onClose(null)
    reset()
  }

  const addUser = (user: IUser) => {
    onClose({...user})
    reset()
  }

  return (<Dialog onClose={handleClose} open={open}>
    <DialogTitle>Create user</DialogTitle>
    <DialogContent>
      <Box component="form">
        <TextField
          autoFocus
          required
          margin="dense"
          id="email"
          label="Email"
          type="email"
          fullWidth
          {...register('email')}
          error={!!errors.email}
          helperText={errors.email?.message}
        />
        <TextField
          required
          margin="dense"
          id="first_name"
          label="First Name"
          type="text"
          fullWidth
          {...register('first_name')}
          error={!!errors.first_name}
          helperText={errors.first_name?.message}
        />
        <TextField
          required
          margin="dense"
          id="last_name"
          label="Last Name"
          type="text"
          fullWidth
          {...register('last_name')}
          error={!!errors.last_name}
          helperText={errors.last_name?.message}
        />
        <div className='avatar-preview'>
          <TextField
            required
            margin="dense"
            id="avatar"
            label="Avatar URL"
            type="text"
            fullWidth
            {...register('avatar')}
            error={!!errors.avatar}
            helperText={errors.avatar?.message}
          />
          {
            getValues().avatar && !errors.avatar ?
              <img className='avatar-image' alt={getValues().first_name} src={getValues().avatar} />
              : <></>
          }
        </div>
      </Box>
    </DialogContent>
    <DialogActions>
      <Button onClick={handleClose}>Cancel</Button>
      <Button type="submit" color="primary" onClick={handleSubmit(addUser)}>Create</Button>
    </DialogActions>
  </Dialog>)
}

export default UserCreateDialog