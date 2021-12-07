<template>
  <div class="home">
    <h1>Home</h1>
    <p>Your content goes here. Make it look nice.</p>
    <ul class="list-group">
      <properties-list
      v-for="properties of properties"
      v-bind:key="properties.id"
      v-bind:properties="properties"
      />
    </ul>
  </div>
</template>

<script>
import PropertiesList from '../components/PropertiesList.vue';
import PropertiesService from '../services/PropertyService.js';
export default {
  components: {
    PropertiesList
  },
  name: "home",
  data() {
    return {properties: [],
    itemsToAdd: {
      id: 0,
      name: " ",
      address: " ",
      isAvailable: false

    }}
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
    }
  
};
</script>
