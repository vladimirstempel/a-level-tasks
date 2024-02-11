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
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFnsV3'
import { yupResolver } from '@hookform/resolvers/yup'
import { resourceValidationSchema } from '../../../shared/validations'
import {UserUpdateDialogProps} from '../../User/components/UserUpdateDialog'

export interface ResourceUpdateDialogProps {
  open: boolean;
  onClose: (value: IResource | null) => Promise<void>;
  providedResource: IResource;
}

const ResourceUpdateDialog: FC<ResourceUpdateDialogProps> = (props: ResourceUpdateDialogProps): ReactElement => {
  const { onClose, open, providedResource } = props

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
    control,
    setError,
    setValue,
    clearErrors
  } = useForm({
    defaultValues: providedResource,
    resolver: yupResolver(resourceValidationSchema)
  })

  const handleClose = () => {
    onClose(null)
    reset()
  }

  const updateResource = (resource: IResource) => {
    onClose({ ...resource })
    reset()
  }

  return (
    <Dialog onClose={ handleClose } open={ open }>
      <DialogTitle>Update resource</DialogTitle>
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
                  helperText: errors.year?.message,
                  defaultValue: providedResource.year
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
                  defaultValue={providedResource.color}
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
        <Button type="submit" color="primary" onClick={ handleSubmit(updateResource) }>Update</Button>
      </DialogActions>
    </Dialog>
  )
}

export default ResourceUpdateDialog