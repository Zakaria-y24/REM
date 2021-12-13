<template>
  <div class="home">
    <div class="properties-container">
      <h3 class="text-center mt-3">My Properties</h3>

      <div class="d-flex p-2 justify-content-around">
        <div class="row gap-5">
          <my-properties-list
            v-for="properties of properties"
            v-bind:key="properties.id"
            v-bind:properties="properties"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import MyPropertiesList from "../components/MyPropertiesList.vue";
import PropertiesService from "../services/PropertyService.js";


export default {
  components: {
    MyPropertiesList,
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
    PropertiesService.getAllMyProperties()
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