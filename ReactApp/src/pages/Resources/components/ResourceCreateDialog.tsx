import React, { FC, ReactElement } from 'react'
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  TextField
} from '@mui/material'
import { DatePicker, LocalizationProvider } from '@mui/x-date-pickers'
import '@styles/App.scss'
import { IResource } from '../../../interfaces/resource'
import { Controller, ErrorOption, useForm } from 'react-hook-form'
import { yupResolver } from '@hookform/resolvers/yup'
import { resourceValidationSchema } from '../../../shared/validations'
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFnsV3'

export interface ResourceCreateDialogProps {
  open: boolean;
  onClose: (value: IResource | null) => Promise<void>;
}

const ResourceCreateDialog: FC<ResourceCreateDialogProps> = (props: ResourceCreateDialogProps): ReactElement => {
  const { onClose, open } = props

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
    control,
    setValue,
    setError,
    clearErrors
  } = useForm({
    resolver: yupResolver(resourceValidationSchema)
  })

  const handleClose = () => {
    onClose(null)
    reset()
  }

  const addResource = (resource: IResource) => {
    onClose({ ...resource })
    reset()
  }

  return (<Dialog onClose={ handleClose } open={ open }>
    <DialogTitle>Create resource</DialogTitle>
    <DialogContent>
      <Box component="form">
        <TextField
          autoFocus
          required
          margin="dense"
          id="name"
          label="Name"
          type="text"
          fullWidth
          { ...register('name') }
          error={ !!errors.name }
          helperText={ errors.name?.message }
        />
        <LocalizationProvider dateAdapter={ AdapterDateFns }>
          <DatePicker
            label="Year"
            className={ 'date-picker-control date-picker-control--full-width' }
            openTo="year"
            views={ ['year'] }
            slotProps={ {
              textField: {
                ...register('year'),
                error: !!errors.year,
                helperText: errors.year?.message
              }
            } }
            onChange={ (value) => {
              if (!value) {
                setError('year', errors.year as ErrorOption)
              } else {
                setValue('year', value as Date)
                clearErrors('year')
              }
            } }
          />
        </LocalizationProvider>
        <Controller
          name='color'
          control={control}
          render={
            ({field: { onChange }}) => (
              <TextField
                required
                margin="dense"
                label="Color"
                type="color"
                fullWidth
                error={ !!errors.color }
                helperText={ errors.color?.message }
                onChange={ onChange }
              />
            )
          }
        />
        <TextField
          required
          margin="dense"
          id="pantone_value"
          label="Pantone Value"
          type="text"
          fullWidth
          { ...register('pantone_value') }
          error={ !!errors.pantone_value }
          helperText={ errors.pantone_value?.message }
        />
      </Box>
    </DialogContent>
    <DialogActions>
      <Button onClick={ handleClose }>Cancel</Button>
      <Button type="submit" color="primary" onClick={ handleSubmit(addResource) }>Create</Button>
    </DialogActions>
  </Dialog>)
}

export default ResourceCreateDialog