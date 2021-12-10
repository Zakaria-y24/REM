<template>
<div>
<section class="PropertyDetails">
  <property-details v-bind:property="Property" />
</section>
</div>
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
  .PropertyDetails {
    text-align: center;
    color: white;
    width: 300px;
  border: 15px solid #76BFED;
  padding: 50px;
  margin: 20px;
  }

  body {
     background-image: url("https://external-preview.redd.it/orB818nEmNCypKfxPNQSVxOFIg6q8iNsvYGwMgk6Irg.jpg?auto=webp&s=1e3519053e8c865fc82667770e58d0d9469343d9") ;
  }
</style>