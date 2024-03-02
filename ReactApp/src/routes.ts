// pages
import Home from "./pages/Home";
import About from "./pages/About";
import Products from "./pages/Products";
import User from "./pages/User";

// other
import {FC} from "react";
import Resource from './pages/Resource'
import Resources from './pages/Resources'
import Login from './pages/Auth'
import Registration from './pages/Auth/Registration'

// interface
interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    authRequired: boolean,
    component: FC<object>
}

export const routes: Array<Route> = [
    {
        key: 'login-route',
        title: 'Login',
        path: '/login',
        enabled: true,
        authRequired: false,
        component: Login
    },
    {
        key: 'registration-route',
        title: 'Registration',
        path: '/registration',
        enabled: true,
        authRequired: false,
        component: Registration
    },
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        authRequired: true,
        component: Home
    },
    {
        key: 'about-route',
        title: 'About',
        path: '/about',
        enabled: true,
        authRequired: true,
        component: About
    },
    {
        key: 'products-route',
        title: 'Products',
        path: '/products',
        enabled: true,
        authRequired: true,
        component: Products
    },
    {
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: false,
        authRequired: true,
        component: User
    },
    {
        key: 'resource-route',
        title: 'Resource',
        path: '/resource/:id',
        enabled: false,
        authRequired: true,
        component: Resource
    },
    {
        key: 'resource-list-route',
        title: 'Resource List',
        path: '/resource',
        enabled: true,
        authRequired: true,
        component: Resources
    }
]