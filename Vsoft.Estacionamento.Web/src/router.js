import Vue from 'vue'
import Router from 'vue-router'

// Login
import LoginView from '@/views/Login/LoginView'

// Admin
import AdminView from '@/views/Admin/AdminView'
import VagasView from '@/views/Admin/VagasView'
import EntradasView from '@/views/Admin/EntradasView'
import FinanceiroView from '@/views/Admin/FinanceiroView'
import PerfilView from '@/views/Admin/PerfilView'

Vue.use(Router)

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            redirect: '/login'
        },
        {
            path: '/login',
            component: LoginView
        },
        {
            path: '/admin',
            component: AdminView,
            redirect: '/admin/vagas',
            children: [
                {
                    path: 'vagas',
                    component: VagasView
                },
                {
                    path: 'relatorios/entradas',
                    component: EntradasView,
                    alias: 'relatorios'
                },
                {
                    path: 'relatorios/financeiro',
                    component: FinanceiroView
                },
                {
                    path: 'perfil',
                    component: PerfilView
                },
            ]
        }
    ]
})
