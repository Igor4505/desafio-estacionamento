<template>
    <div class="perfil">
        <h1>Perfil</h1>
        <div class="perfil__content">
            <div class="perfil__dados">
                <id-input placeholder="Nome"/>
                <id-input placeholder="CPF"/>
                <id-input placeholder="E-mail"/>
            </div>
        </div>
    </div>
</template>

<script>
import IdInput from '@/components/controls/id-Input'
export default {
    components: {
        IdInput
    }
};
</script>

<style>
.perfil{
    height: 100%;
    display: flex;
    flex-direction: column;
    padding: 30px;
}
.perfil__content{
    flex: 1;
    display: flex;
    align-items: center;
    justify-content: center;
}

.perfil__dados{
    width: 400px;
    height: 300px;
    background: #FFFFFF;
    box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.25);
    border-radius: 5px;
    padding: 20px;
    display: flex;
    flex-direction: column;
    justify-content: space-around;
}
</style>