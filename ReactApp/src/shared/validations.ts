import * as Yup from 'yup'
import { Credentials, RegistrationCredentials } from '../interfaces/credentials'

export const userValidationSchema = Yup.object().shape({
  email: Yup.string()
    .required('Email is required')
    .email('Incorrect email format'),
  first_name: Yup.string()
    .required('First name is required')
    .min(2, 'First name must be at least 2 chars'),
  last_name: Yup.string()
    .required('Last name is required')
    .min(2, 'Last name must be at least 2 chars'),
  avatar: Yup.string()
    .required('Avatar is required')
    .url('Incorrect url format')
})

export const resourceValidationSchema = Yup.object().shape({
  name: Yup.string()
    .required('Name is required')
    .min(2, 'Name must be at least 2 chars'),
  year: Yup.date()
    .required('Year is required'),
  color: Yup.string()
    .required('Color is required'),
  pantone_value: Yup.string()
    .required('Pantone value is required')
    .min(2, 'Pantone value must be at least 2 chars')
})

export const loginValidationSchema = Yup.object<Credentials>().shape({
  email: Yup.string()
    .required('Email is required')
    .email('Incorrect email format'),
  password: Yup.string()
    .required('Password is required')
    .min(3, 'Min 3 chars')
    .max(25, 'Max 25 chars')
})

export const registrationValidationSchema = Yup.object<RegistrationCredentials>().shape({
  email: Yup.string()
    .required('Email is required')
    .email('Incorrect email format'),
  password: Yup.string()
    .required('Password is required')
    .min(3, 'Min 3 chars')
    .max(25, 'Max 25 chars'),
  confirmPassword: Yup.string()
    .required('Password is required')
    .min(3, 'Min 3 chars')
    .max(25, 'Max 25 chars')
    .oneOf([Yup.ref('password')], 'Passwords must match')
})