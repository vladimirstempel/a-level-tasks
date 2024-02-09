// pages
import Home from "./pages/Home";
import About from "./pages/About";
import Products from "./pages/Products";
import User from "./pages/User";

// other
import {FC} from "react";
import Resource from './pages/Resource'
import Resources from './pages/Resources'

// interface
interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
        enabled: true,
        component: Home
    },
    {
        key: 'about-route',
        title: 'About',
        path: '/about',
        enabled: true,
        component: About
    },
    {
        key: 'products-route',
        title: 'Products',
        path: '/products',
        enabled: true,
        component: Products
    },
    {
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: false,
        component: User
    },
    {
        key: 'resource-route',
        title: 'Resource',
        path: '/resource/:id',
        enabled: false,
        component: Resource
    },
    {
        key: 'resource-list-route',
        title: 'Resource List',
        path: '/resource',
        enabled: true,
        component: Resources
    }
]