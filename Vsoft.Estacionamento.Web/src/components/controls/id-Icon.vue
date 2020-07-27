<template>
    <div :style="[{'width': size},
                  {'height': size},
                  {'background-color': color},
                  {'mask-image': 'url('+ require('@/assets/icons/'+icon+'.svg') +')'}]"
                   class="symbol"></div>
</template>

<script>
export default {
props:{
        icon: {
            type: String,
            default: "cog"
        },
        size:{
            type: String,
            default: "20px"
        },
        color: {
            type: String,
            default: "#303030"
        }
    }
}
</script>

<style>
.symbol {
    display: inline-block;
    mask-repeat: no-repeat;
    mask-position: center;
    mask-size: contain;
    transition: .3s;
}
</style>
