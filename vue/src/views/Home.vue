<template>
<div>
  <div class="home">
    <h1>Home</h1>
    <p>List of Available Properties</p>
    <ul class="list-group">
      <properties-list
      v-for="properties of properties"
      v-bind:key="properties.id"
      v-bind:properties="properties"/>
    </ul>
  </div>
  <add-property />
</div>
</template>

<script>
import PropertiesList from '../components/PropertiesList.vue';
import PropertiesService from '../services/PropertyService.js';
import AddProperty from '../components/AddProperty.vue';

export default {
  components: {
    PropertiesList,
    AddProperty
  },
  name: "home",
  data() {
    return {properties: [],
    itemsToAdd: {
      name: " ",
      address: " "
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
