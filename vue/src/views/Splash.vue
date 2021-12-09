<template>
  <div class="home">
    <splash-page />
    <div class="properties-container">
      <h3 class="text-center mt-3">Available Properties</h3>

      <div class="d-flex p-2 justify-content-around">
        <div class="row gap-5">
          <properties-list
            v-for="properties of properties"
            v-bind:key="properties.id"
            v-bind:properties="properties"
          />
        </div>
        <add-property
          v-bind:properties="properties"
          v-if="isLoggedIn && isAdmin"
        />
        <property-details v-if="!isLoggedIn && !isAdmin" />
      </div>
    </div>
  </div>
</template>

<script>
import PropertiesList from "../components/PropertiesList.vue";
import PropertiesService from "../services/PropertyService.js";
import AddProperty from "../components/AddProperty.vue";
import PropertyDetails from "../components/PropertyDetails.vue";
import SplashPage from "../components/SplashPage.vue";

export default {
  components: {
    PropertiesList,
    AddProperty,
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

</style>