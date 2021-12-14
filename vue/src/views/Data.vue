<template>
  <section>
    
  </section>
</template>

<script>
import { Pie} from 'vue-chartjs'
export default {
    extends: Pie,
    props:['data', 'options' ],
    mounted(){
        this.renderChart(this.data,this.options)
    },
}
</script>

<style>

</style>