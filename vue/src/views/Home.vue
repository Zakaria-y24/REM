<template>
  <div class="home">
    <splash-page />
    <div class="container text-center p-2 filter-container">
      <h2 class="filter-label">Filter Options</h2>
     <form class="row">
    <div class="filterOptions">
      <div class="input-group input-group-sm flex-nowrap">
    <label class="searches col-form-label" for="zipcode">ZipCode:</label>
    <input  type="text" v-model="zipcode" id="zipcode" class="form-control"/>
      </div>
      <div class="input-group input-group-sm flex-nowrap">
    <label class="searches col-form-label" for="beds">Beds:</label>
    <input type="text" v-model="beds" id="beds" class="form-control"/>
      </div>
      <div class="input-group input-group-sm flex-nowrap">
    <label class="searches col-form-label" for="baths">Baths:</label>
    <input type="text" v-model="baths" id="baths" class="form-control"/>
      </div>
      <div class="input-group input-group-sm flex-nowrap">
    <label class="searches col-form-label" for="rent">Rent:</label>
    <input type="text" v-model="rent" id="rent" class="form-control"/>
    </div>
    <div class="input-group input-group-sm flex-nowrap">
    <label class="searches col-form-label" for="size">Size:</label>
    <input type="text" v-model="size" id="size" class="form-control"/>
    </div>
    <div class="input-group input-group-sm">
      <label class="searches col-form-label" for="type">Property Type: </label>
      <select v-model="type" id="type" class="form-select form-select-sm">
       <option value="">Show All</option>
       <option value="House">House</option>
       <option value="Apartment">Apartment</option>
       <option value="Bussiness">Business</option>
     </select>
    </div>
    </div>
    </form>
    </div>
      <h3 class="text-center mt-3">Available Properties</h3>

      <div class="d-flex p-2 justify-content-around">
        <div class="row gap-5">
        </div>
          <properties-list
            v-for="properties of filteredProperties"
            v-bind:key="properties.id"
            v-bind:properties="properties"
          />
    <div class="properties-container">
        <property-details v-if="isLoggedIn && !isAdmin" />
      </div>
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
      zipcode: "",
      beds: "",
      baths: "",
      rent: "",
      size: "",
      type: "",
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
    filteredProperties() {
      return this.properties.filter((p) => {
        if (!p.zipcode.toLowerCase().includes(this.zipcode.toLowerCase())) {
          return false;
        }
        if (p.beds <= this.beds) {
          return false;
        }
        if (p.baths <= this.baths) {
          return false;
        }
        if (p.rent <= this.rent) {
          return false;
        }
        if (p.size <= this.size) {
          return false;
        }
        if (!p.type.toLowerCase().includes(this.type.toLowerCase())) {
          return false;
        }

        return true;
      });
    },
  },
};
</script>
<style scoped>
body {
  color: #333;
}
.filterOptions {
  display: flex;
  flex-direction: row;
  padding: 0 3rem;
}
.searches {
  padding-right: 10px;
  padding-left: 10px;

}
.filter-label {
  margin-bottom: 15px;
}
.filter-container{
  background-color: #f4f4f4;
}

.container{
  max-width: 100%;
}

select {
  height: 31px;
}
</style>
