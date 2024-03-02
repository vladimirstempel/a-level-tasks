import React, { createContext } from 'react'
import App from './App';
import reportWebVitals from './reportWebVitals';
import Auth from './state/Auth'
import { createRoot } from 'react-dom/client'

const auth = new Auth()
export const AuthContext = createContext<Auth>(auth)

const root = createRoot(
  document.getElementById('root')!
)

root.render(
  <React.StrictMode>
    <AuthContext.Provider value={auth}>
      <App />
    </AuthContext.Provider>
  </React.StrictMode>,
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
