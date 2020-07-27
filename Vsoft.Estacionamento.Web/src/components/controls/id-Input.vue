<template>
    <div class="id-input">
        <label :for="name" class="id-input__placeholder" :class="{'--active': isActive || text.length}">{{ placeholder }}</label>
        <input @focus="isActive = true"
               @blur="isActive = text.length"
               @input="$emit('input', text)"
               :type="type"
               :name="name"
               :id="name"
               :readonly="readonly"
               v-model="text"
               class="id-input__input"/>
    </div>
</template>

<script>
export default {
    props: {
        placeholder: {
            type: String,
            default: 'input'
        },
        value: {
            type: String,
            default: ''
        },
        type: {
            type: String,
            default: "text"
        },
        name: {
            type: String,
            required: true
        },
        readonly: {
            type: Boolean,
            default: false
        }
    },
    data(){
        return {
            isActive: false,
            text: this.value
        }
    },
    methods: {
        typed(){
            console.log(this.value.length > 0)
            this.value.length ? this.isActive = true : this.isActive = false
        }
    }
}
</script>

<style>
.id-input{
    position: relative;
    height: 50px;
    width: 100%;
    display: flex;
    align-items: flex-end;
    padding-bottom: 10px;
    margin-top: 10px;
    border-bottom: solid #BEBEBE 1px;
}
.id-input__input{
    width: 100%;
    border: none;
    outline: none;
    font-size: 14px;
    font-weight: var(--semibold);
    color: var(--gray-1);
}
.id-input__placeholder{
    position: absolute;
    bottom: 10px;
    font-size: 14px;
    transition: .3s;
    font-weight: var(--semibold);
    color: var(--gray-1);
}

.--active{
    bottom: 35px;
    font-size: 10px;
    font-weight: var(--bold);
}
</style>