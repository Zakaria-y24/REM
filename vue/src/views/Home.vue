<template>
  <div class="home">
    <h1>Home</h1>
    <h2> List of Available Properties</h2>
    <ul class="list-group">
      <properties-list
      
      v-for="properties of properties"
      v-bind:key="properties.id"
      v-bind:properties="properties" 
      />
      <add-property v-bind:addedProperties="properties" v-if="isLoggedIn" />
    </ul>
  </div>
</template>

<script>
import PropertiesList from '../components/PropertiesList.vue';
import PropertiesService from '../services/PropertyService.js';
import AddProperty from '../components/AddProperty';


export default {
  components: {
    PropertiesList,
    AddProperty,
  },
  name: "home",
  data() {
    return {properties: [],
    itemsToAdd: {
      id: 0,
      name: " ",
      street: "",
      city: "",
      zipcode:"",
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
    },
    computed: {
    isLoggedIn() {
      return this.$store.state.token;
    },
    isAdmin() {
      return this.$store.state.user && 
             this.$store.state.user.role === 'admin';
    }
  },  
  
};
</script>
<style>

</style>
