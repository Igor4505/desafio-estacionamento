<template>
    <nav class="master-page" :style="masterPageStyle" ref="master" >
        <ul class="master-page__menu" :style="masterMenuStyle">
            <slot/>
        </ul>
        <transition name="fade">
            <div class="shadow" v-if="showShadow && paneOpened"></div>
        </transition>
    </nav>
</template>

<script>
export default {
    mounted() {
        this.parentDirection = getComputedStyle(this.$refs.master.parentElement).flexDirection
    },
    props: {
        mode: {
            type: String,
            default: 'Inline',
        },
        paneOpened: {
            default: false,
            type: Boolean
        },
        closedPaneLenght: {
            default: "55px",
            type: String
        },
        openedPaneLenght: {
            default: "300px",
            type: String
        },
        showShadow: {
            type: Boolean,
            default: false
        }
    },
    data() {
        return {
            parentDirection: ''
        }
    },
    computed: {
        masterPageStyle() {
            switch (this.mode) {
                case 'CompactInline':
                    return [
                        {'width': this.paneOpened ? this.openedPaneLenght : this.closedPaneLenght}
                    ]
                case 'Inline':
                    return [
                        {'width': this.paneOpened ? this.openedPaneLenght : '0px'}
                    ]
                case 'CompactOverlay':
                    return [
                        { 'width': this.closedPaneLenght },
                        { 'overflow': 'visible'}
                    ]
                case 'Overlay':
                    return [
                        { 'width': '0px' },
                        { 'overflow': 'visible'}
                    ]
                default:
                    return []
            }
        },
        masterMenuStyle() {
            switch (this.mode) {
                case 'CompactInline':
                case 'Inline':
                    return [
                        {'width': this.openedPaneLenght }
                    ]
                case 'CompactOverlay':
                    return [
                        { 'width': this.paneOpened ? this.openedPaneLenght : this.closedPaneLenght },
                        { 'position': 'absolute'},
                        { 'left': this.parentDirection == 'row' ? '0' : 'auto'},
                        { 'right': this.parentDirection == 'row-reverse' ? '0' : 'auto'}
                    ]
                case 'Overlay':
                    return [
                        { 'width': this.paneOpened ? this.openedPaneLenght : '0px' },
                        { 'position': 'absolute'},
                        { 'left': this.parentDirection == 'row' ? '0' : 'auto'},
                        { 'right': this.parentDirection == 'row-reverse' ? '0' : 'auto'}
                    ]
                default:
                    return []
            }
        }
    }
}
</script>

<style>
/* MASTER PAGE*/
.master-page {
    transition: .5s;
    display: flex;
    flex-direction: column;
    position: relative;
}

.master-page__menu{
    display: flex;
    transition: .5s;
    top: 0;
    bottom: 0;
    margin: 0;
    flex: 1;
    white-space: nowrap;
    z-index: 7
}

.master-page__content{
    z-index: 7
}

.shadow {
    position: fixed;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0,0,0,.4);
    z-index: 6;
}
</style>
