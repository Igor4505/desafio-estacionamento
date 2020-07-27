<template>
    <master-detail-page>
        <master-page class="master-page"
                     slot="MasterPage"
                     :mode="isMobile ? 'CompactOverlay' : 'CompactInline'" :paneOpened="paneOpened"
                     :showShadow="isMobile">
            <nav class="menu-principal">
                <div class="menu-principal__header">
                    <img class="logo" src="@/assets/img/logo.svg" :class="{'--active' : paneOpened}"/>
                </div>
                <div class="menu-principal__opcoes" :class="{'--menu-active': paneOpened}">
                    <router-link to="/admin/vagas" class="route" active-class="route-active">
                        <id-icon icon="car" size="25px" color="var(--primary-color)"/>
                        <span>Vagas</span>
                    </router-link>
                    <router-link to="/admin/relatorios" class="route" active-class="route-active">
                        <id-icon icon="file" size="25px" color="var(--primary-color)"/>
                        <span>Relatorios</span>
                    </router-link>
                    <router-link to="/admin/perfil" class="route" active-class="route-active">
                        <id-icon icon="user" size="25px" color="var(--primary-color)"/>
                        <span>Pefil</span>
                    </router-link>
                </div>
                <div class="menu-principal__footer" @click="paneOpened = !paneOpened">
                    <id-icon icon="close" size="30px" color="var(--primary-color)" :class="{'--isClosed': !paneOpened}"/>
                </div>
            </nav>
        </master-page>
        <detail-page slot="DetailPage" class="detail-page">
            <header>
                <div class="header__content">
                    <p>Bem-vindo Igor Dantas</p>
                    <button class="logout-button" @click="$router.push('/login')">Sair</button>
                </div>
            </header>
            <router-view/>
        </detail-page>
    </master-detail-page>
</template>

<script>
import MasterDetailPage from '@/components/pages/MasterDetailPage/MasterDetailPage'
import MasterPage from '@/components/pages/MasterDetailPage/MasterPage'
import DetailPage from '@/components/pages/MasterDetailPage/DetailPage'
import IdIcon from '@/components/controls/id-Icon'

export default {
    created(){
        this.paneOpened = !this.isMobile
    },
    components: {
        MasterDetailPage,
        MasterPage,
        DetailPage,
        IdIcon
    },
    data(){
        return {
            paneOpened: true
        }
    },
    computed: {
        isMobile(){
            return this.$store.state.isMobile
        }
    }
}
</script>

<style>
.admin-view{
    height: 100%;
    width: 100%;
}
.detail-page{
    display: flex;
    flex-direction: column;
    background-color: #F7F7F7;
    
}
.detail-page header{
    width: 100%;
    padding-left: 30px;
    color: var(--gray-1);
    overflow: visible;
}
.header__content{
    padding: 15px;
    border-bottom: solid var(--gray-2) 1px;
    display: flex;
    justify-content: flex-end;
    align-items: center;
}
.master-page{
    box-shadow: 2px 0px 4px rgba(0, 0, 0, 0.25);
}
.menu-principal{
    width: 100%;
    height: 100%;
    background: white;
    display: flex;
    flex-direction: column;
}
.menu-principal__opcoes{
    flex: 1;
    display: flex;
    flex-direction: column;
    justify-content: center;
    transition: .5s;
}
.--menu-active{
    margin-left: 30px;
}
.menu-principal__footer{
    height: 45px;
    border-top: solid var(--gray-2) 1px;
    display: flex;
    align-items: center;
    justify-content: flex-start;
    padding: 0 12px;
}
.menu-principal__header{
    display: flex;
    overflow: visible;
    transition: .5s;
    position: relative;
}

.logo{
    height: 25px;
    transition: .5s;
    position: absolute;
    top: 15px;
    left: 15px;
}
.logo.--active{
    height: 40px;
    left: 50%;
    transform: translate(-50%);
}

.route{
    font-weight: var(--black);
    text-decoration: none;
    color: var(--primary-color);
    margin: 5px 0;
    height: 50px;
    
    display: flex;
    align-items: center;
    padding-left: 15px;
    transition: .5s;
}
.--menu-active .route{
    border-top-left-radius: 25px;
    border-bottom-left-radius: 25px;
}
.route:hover {
    background-color: var(--gray-3);
}
.route span{
    padding: 0 15px;
}

.route-active{
    background-color: rgba(62,64,149, .2)
}
.--isClosed{
    transform: rotate(180deg);
}
.logout-button{
    height: 30px;
    border: 1px solid #838383;
    color: var(--gray-1);
    border-radius: 15px;
    background-color: transparent;
    padding: 0 25px;
    margin-left: 20px;
    font-weight: var(--bold);
    transition: .3s;
}

.logout-button:hover{
    background-color: var(--primary-color);
    border: 1px solid transparent;
    color: white;
}

</style>