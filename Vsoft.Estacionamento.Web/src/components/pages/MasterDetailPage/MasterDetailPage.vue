<template>
    <div id="MasterDetailPage">
        <div class="MasterDetailHeader">
            <slot name="Header"/>
        </div>
        <div id="MasterDetailContent" :style="{'flex-direction': position}">
            <slot name="MasterPage"/>
            <slot name="DetailPage"/>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        masterPosition: {
            type: String,
            default: 'left'
        }
    },
    computed: {
        position(){
            switch(this.masterPosition) {
                case 'left':
                    return 'row'
                case 'right':
                    return 'row-reverse'
                case 'top':
                    return 'column'
                case 'bottom':
                    return 'column-reverse'
                default:
                    return ''
            }
        }
    }
};
</script>

<style>
/* MASTER DETAIL PAGE*/
#MasterDetailPage {
    display: flex;
    align-items: stretch;
    flex-direction: column;
    height: 100%;
}

.MasterDetailHeader{
    width: 100%;
    overflow: visible;
}

.MasterDetailHeader * {
    overflow: visible
}

#MasterDetailContent{
    display: flex;
    width: 100%;
    align-items: stretch;
    flex: 1
}
</style>
