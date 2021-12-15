<template>
  <div>
    <h2>Vacancy Chart</h2>

    <GChart
      type="PieChart"
      :options="options"
      :data="vacantData"
    />
        
  </div>
</template>
 
<script>
import { GChart } from "vue-google-charts";

export default {
 props: {
        properties: Array,
    },
  components: {
    GChart
  },
  data() {
    return {
       
        options: {
            width: 1100,
        height: 400
      }
    };
  },
  computed: {
      vacantProperties(){
          return this.properties.filter((p) => {
              if(!p.isAvailable){
                  return false;
              }
              return true;
          })

      },
      occupiedProperties(){
          return this.properties.filter((p) => {
              if(!p.isAvailable){
                  return true;
              }
              return false;
          })

      },
       vacantData(){
           return [
            ['Vacancy', 'Number of Properties'],
            ['Vacant',     this.vacantPropertiesCount],
            ['Occupied',      this.occupiedProperties.length],
        ]
       },
      vacantPropertiesCount(){
          return this.vacantProperties.length;
      },
  }
};
</script>