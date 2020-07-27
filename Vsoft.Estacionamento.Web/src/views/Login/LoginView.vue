<template>
    <div class="login-view">
        <div class="login-view__background"></div>
        <div class="login-view__form-container">
            <div class="login-view__form">
                <img class="login-view__logo" src="@/assets/img/logo.svg"/>
                <div>
                    <id-input placeholder="E-mail" name="email" class="login-view__inputs" v-model="email"/>
                    <id-input placeholder="Senha" name="senha" class="login-view__inputs" type="password" v-model="senha"/>
                </div>
                <button class="login-view__submit" @click="$router.push('/admin')">LOGIN</button>
            </div>
        </div>
    </div>
</template>

<script>
import IdInput from '@/components/controls/id-Input.vue'
export default {
    components: {
        IdInput
    },
    data() {
        return {
            email: '',
            senha: ''
        }
    }
}
</script>

<style>
.login-view{
    width: 100%;
    height: 100%;
    display: flex;
    position: relative;
}

.login-view__background{
    flex: 1;
    background-image: url("~@/assets/img/loginback.webp");
    background-size: cover;
    background-position: center;
}
.login-view__form-container{
    width: 500px;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 0 60px;
    background-color: white;
}

@media (min-width: 451px) and (max-width: 900px) {
    .login-view__form-container{
        position: absolute;
        top: calc(50% - 200px);
        left: calc(50% - 175px);
        width: 350px;
        height: 400px;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0,0,0,.5)
        
    }
}

@media (max-width: 450px) {
    .login-view__form-container{
        position: absolute;
        top: calc(50% - 200px);
        left: 10%;
        width: 80%;
        height: 400px;
        border-radius: 10px;
        box-shadow: 0 0 10px rgba(0,0,0,.5);
        padding: 20px;
    }
}
.login-view__form{
    width: 100%;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    height: 300px;
}
.login-view__submit{
    width: 100%;
    height: 50px;
    background: #3E4095;
    border-radius: 25px;
    border: none;
    color:white;
    font-weight: var(--semibold);
}
.login-view__inputs{
    margin-bottom: 10px;
}
</style>