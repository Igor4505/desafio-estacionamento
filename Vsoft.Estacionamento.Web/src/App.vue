<template>
    <div id="app">
        <router-view/>
    </div>
</template>

<script>


export default {
    created(){
        window.addEventListener('resize', this.resize)
        this.$store.state.isMobile = window.innerWidth < 900
    },
    methods:{
        resize(){
            this.$store.state.isMobile = window.innerWidth < 900
        }
    }
}
</script>

<style>
* {
    margin: 0;
    padding: 0;
    font-family: 'Roboto', sans-serif;
    box-sizing: border-box;
    overflow: hidden;
    flex-shrink: 0;
}
:root{
    --light: 300;
    --regular: 400;
    --semibold: 500;
    --bold: 700;
    --black: 900;

    --primary-color: #3E4095;
    --gray-1: #484848;
    --gray-2: #CCCCCC;
    --gray-3: #EBEBEB;
}
html, body, #app{
    height: 100%;
}

[flex-1]{
    flex: 1
}

h1 {
    color: var(--primary-color);
    font-size: 24px;
    font-weight: var(--light);
}
h2 {
    font-size: 18px;
    font-weight: var(--bold);
    color: var(--primary-color);
}
h3 {
    font-size: 18px;
    font-weight: var(--bold);
    color: var(--gray-1);
}
p {
    color: var(--gray-1);
    font-size: 16px;
    font-weight: var(--regular);
}
b {
    font-weight: var(--bold);
    color: var(--primary-color);
}
button {
    cursor: pointer;
}
.fade-enter, .fade-leave-to{
    opacity: 0;
}
.fade-enter-active, .fade-leave-active{
    transition: .3s ease-out;
}
.modalShow-enter, .modalShow-leave-to{
    transform: scale(.97);
    opacity: 0;
    
}
.modalShow-enter-active, .modalShow-leave-active{
    transition: .2s ease-out .2s;
}
.--btn-active{
    border: solid rgba(62,64,149, .5) 2px;
}
</style>
