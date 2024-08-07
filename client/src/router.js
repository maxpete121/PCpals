import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/MyBuilds',
    name: 'myBuilds',
    component: loadPage('MyBuildsPage')
  },
  {
    path: '/BrowseBuilds',
    name: 'Browse',
    component: loadPage('BrowseBuildsPage')
  },
  {
    path: '/EditBuild/:buildId',
    name: 'EditBuild',
    component: loadPage('EditBuildPage')
  },
  {
    path: '/Clean',
    name: 'Clean',
    component: loadPage('CleaningPage')
  },
  {
    path: '/Contact',
    name: 'Contact',
    component: loadPage('ContactPage')
  },
  {
    path: '/Admin',
    name: 'Admin',
    component: loadPage('AdminPage')
  },
  {
    path: '/Checkout',
    name: 'Checkout',
    component: loadPage('CheckoutPage')
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  },
  {
    path: '/info',
    name: 'Info',
    component: loadPage('InfoPage'),
  }
]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})
