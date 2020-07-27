<template>
    <div class="vaga" @click="$emit('onPressed')">
        <div class="vaga__content">
            <div class="vaga__header">
                <p v-if="texto == '+'">Adicionar vaga</p>
                <p v-if="ocupada">{{ placa }}</p>
                <p v-if="ocupada"><b> {{ tempo }}</b></p>
            </div>
            <div class="vaga__body">
                <img v-if="ocupada" src="@/assets/img/vaga.svg"/>
                <div v-else-if="texto == '+'" >
                    <img class="carregando" v-if="carregando" src="@/assets/img/loading_dots.gif"/>
                    <id-icon v-else icon="plus" size="80px" color="var(--gray-2)"/>
                </div>
                <span :class="{'adicionar': texto == '+'}" v-else>{{ texto }}</span>
            </div>
            <div class="vaga__footer" v-if="ocupada">
                01
            </div>
        </div>
    </div>
</template>

<script>
import idIcon from '@/components/controls/id-Icon'
import { type } from 'os';
import { Stats } from 'fs';
export default {
    components:{
        idIcon
    },
    props: {
        ocupada: {
            type: Boolean,
            default: false
        },
        texto: {
            type: String,
            default: "DISPONÍVEL"
        },
        carregando: {
            type: Boolean,
            default: false
        },
        placa: {
            type: String,
            defaulg: ''
        },
        tempo: {
            type: String,
            default: ''
        },
        numero: {
            type: String,
            default: ''
        }

    }
}
</script>

<style>
.vaga{
    width: 33.3%;
    padding: 16px;
    cursor: pointer;
    transition: .3s;
}


.vaga__content{
    position: relative;
    display: flex;
    flex-direction: column;
    width: 100%;
    height: 200px;
    background-color: white;
    box-shadow: 0px 0px 7px rgba(0, 0, 0, 0.25);
    border-radius: 5px;
    transition: .3s;
}
.vaga__content:hover{
    background-color: #FAFAFA;
}

.vaga__header{
    padding: 0 15px;
    height: 40px;
    align-items: center;
    display: flex;
    justify-content: space-between;
    border-bottom: solid var(--gray-3) 1px;
}
.vaga__body{
    padding: 25px;
}
.vaga__body img{
    width: 70%;
}
.vaga__body{
    flex: 1;
    display: flex;
    align-items: center;
    justify-content: center;
}
.vaga__body span{
    font-weight: var(--bold);
    font-size: 24px;
    line-height: 28px;
    color: var(--gray-2);
}
.vaga__footer{
    position: absolute;
    bottom: 0;
    left: 0;
    padding: 10px 15px;
    font-size: 20px;
    font-weight: var(--bold);
}
.carregando{
    width: 100px !important;
}
@media (min-width: 700px) and (max-width: 1000px) {
    .vaga{
        width: 50%;
    }
}

@media (max-width: 699px) {
    .vaga{
        width: 100%;
    }
    .vaga__content{
        height: 170px;
    }
}
</style>