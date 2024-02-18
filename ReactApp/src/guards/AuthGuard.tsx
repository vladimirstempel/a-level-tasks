import { Navigate } from 'react-router-dom'
import { FC, ReactElement, useContext } from 'react'
import { observer } from 'mobx-react'
import { AuthContext } from '../index'

const AuthGuard: FC<{ children: ReactElement }> = ({ children }): ReactElement => {
  const auth = useContext(AuthContext)

  if (!auth.isLoggedIn) {
    return <Navigate to="/login" replace />
  }
  return children
}

export default observer(AuthGuard)