<template>
    <transition name="fade">
        <div class="modal" v-if="isOpened">
            <transition name="modalShow" appear>
                <div class="modal__container" :class="{'small': size == 'small'}">
                    <div class="modal__header">
                        <h3>{{ title }}</h3>
                        <div @click="$emit('closeModal')" style="cursor:pointer">
                            <id-icon  size="25px" color="var(--gray-1)" icon="times"/>
                        </div>
                    </div>
                    <div class="modal__body">
                        <slot/>
                    </div>
                </div>
            </transition>
        </div>
    </transition>
</template>

<script>
import IdIcon from '@/components/controls/id-Icon'
export default {
    components: {
        IdIcon
    },
    props: {
        title: {
            type: String,
            default: 'Titulo'
        },
        isOpened: {
            type: Boolean,
            default: false
        },
        size: {
            type: String,
            default: 'big'
        }
    }
}
</script>

<style>
.modal {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0,0,0,.8);
    display: flex;
    justify-content: center;
    align-items: center;
    z-index: 100;
}
.modal__container{
    width: 500px;
    border-radius: 10px;
    background-color: white;
    max-height: 85%;
    display: flex;
    flex-direction: column;
}
.small{
    width: 350px;
}
@media (max-width: 520px) {
    .modal__container{
        width: 85%;
        border-radius: 10px;
        background-color: white;
    }
}
.modal__header{
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 25px;
    border-bottom: solid 1px var(--gray-2);
}
.modal__body{
    flex: 1;
    overflow: auto;
}

</style>