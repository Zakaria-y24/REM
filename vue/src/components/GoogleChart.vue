<template>
  <div>
    <h2>Vacancy Chart</h2>

    <GChart type="PieChart" :options="VacancyOptions" :data="vacantData" />

    <h2>Income Graph</h2>
    <GChart type="ColumnChart" :options="options" :data="incomeData" />
  </div>
</template>
 
<script>
import { GChart } from "vue-google-charts";

export default {
  props: {
    properties: Array,
  },
  components: {
    GChart,
  },
  data() {
    return {
      
      options: {
        width: 1100,
        height: 400,
      },
      VacancyOptions: {
        width: 1100,
        height: 400,
      },
    };
  },
  computed: {

    vacantProperties() {
      return this.properties.filter((p) => {
        if (!p.isAvailable) {
          return false;
        }
        return true;
      });
    },
    occupiedProperties() {
      return this.properties.filter((p) => {
        if (!p.isAvailable) {
          return true;
        }
        return false;
      });
    },
    vacantData() {
      return [
        ["Vacancy", "Number of Properties"],
        ["Vacant", this.vacantPropertiesCount],
        ["Occupied", this.occupiedProperties.length],
      ];
    },
    incomeData(){ 
      return [
        ["Income", "Revenue", { role: "style" }],
        ["Revenue", this.revenueData, "#6B58E2"],
        ["Lost Revenue", this.lostRevenueData, "#00B28F"],
        ["Potential Revenue", this.potentialRevenueData, "#F8D12F"],
        ["Average Rent", this.averageRent, "#E63946"]
      ]},
    vacantPropertiesCount() {
      return this.vacantProperties.length;
    },
    revenueData() {
      let totalRent = 0;
      this.properties.forEach((p) => {
        if(!p.isAvailable){
        totalRent += p.rent;
      }});
      return totalRent;
    },
    lostRevenueData() {
      let totalRent = 0;
      this.properties.forEach((p) => {
        if(p.isAvailable){
        totalRent += p.rent;
      }});
      return totalRent;
    },
    potentialRevenueData() {
      let totalRent = 0;
      this.properties.forEach((p) => {
        
        totalRent += p.rent;
      });
      return totalRent;
    },
    averageRent(){
      let totalRent=0;
      this.properties.forEach((p)=>{
        if(!p.isAvailable){
         totalRent += p.rent;
        }
        totalRent /= this.occupiedProperties.length;
      });
      return totalRent;
    }
  },
};
</script>