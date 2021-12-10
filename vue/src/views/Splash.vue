<template>
  <div class="home">
    
    <splash-page />
    <div class="properties-container">
      <p class="h4 text-center mt-3">Available Properties</p>

      <div class="d-flex p-2 justify-content-around">
        <div class="row gap-5">
          <properties-list
            v-for="properties of properties"
            v-bind:key="properties.id"
            v-bind:properties="properties"
          />
        </div>
        
        <property-details v-if="!isLoggedIn && !isAdmin" />
      </div>
    </div>
    <div class="d-flex cta justify-content-center">
      <p class="h4 mb-2 text-center align-self-center">Interested in viewing more properties? <router-link :to="{ name: 'register' }">Register for an account today!</router-link></p>
    </div>
  </div>
</template>

<script>
import PropertiesList from "../components/PropertiesList.vue";
import PropertiesService from "../services/PropertyService.js";
import PropertyDetails from "../components/PropertyDetails.vue";
import SplashPage from "../components/SplashPage.vue";

export default {
  components: {
    PropertiesList,
    PropertyDetails,
    SplashPage,
  },
  name: "home",
  data() {
    return {
      properties: [],
      itemsToAdd: {
        id: 0,
        name: " ",
        street: "",
        city: "",
        zipcode: "",
        isAvailable: false,
      },
    };
  },

  created() {
    PropertiesService.getAllProperties()
      .then((response) => {
        this.properties = response.data;
      })
      .catch((response) => {
        console.error("could not get properties", response);
      });
  },
  computed: {
    isLoggedIn() {
      return this.$store.state.token;
    },
    isAdmin() {
      return this.$store.state.user && this.$store.state.user.role === "admin";
    },
  },
};
</script>
<style scoped>
body {
  color: #333;
}
.cta{
  background-color: #e2e2e2;
  height: 10vh;
}
a{
text-decoration: none;
}

</style>