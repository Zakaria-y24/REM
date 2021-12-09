<template>
<section class="PropertyDetails">
  <property-details v-bind:property="Property" />
</section>
</template>

<script>
import PropertyDetails from '../components/PropertyDetails.vue';
import PropertiesService from '../services/PropertyService.js';

export default {
    name: 'Propertyinfo',
    data(){
        return {
            properties: [],
            
        }
    },
    components: {
        PropertyDetails
    },
    created() {
      PropertiesService
      .getAllProperties()
      .then(response => {
        this.properties = response.data;
      })
      .catch(response => {
        console.error("could not get properties", response);
      });
    },
    computed: {
        Property() {
            if(!this.properties){
                return undefined;
            }
            return this.properties.find(p => p.id == this.$route.params.id);
            
        }
    }
}
</script>
<style>

</style>