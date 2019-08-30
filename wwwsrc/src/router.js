import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'
// @ts-ignore
import CreateVault from './components/CreateVaultComponent.vue'
// @ts-ignore
import CreateKeep from './components/CreateKeepComponent.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/vaults',
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/createkeep',
      name: 'CreateKeep',
      component: CreateKeep
    },
    {
      path: "/createvault",
      name: "CreateVault",
      component: CreateVault
    },
  ]
})
