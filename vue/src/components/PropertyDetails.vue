<template>
  <div class="property-background">
    <section v-if="property" class="property-details">
      <h1 class="property-name">{{ property.name }}</h1>

      <h4 class="property-street">{{ property.street }}</h4>
      <h4 class="property-city">{{ property.city }}, {{property.state}}</h4>
      <h4 class="property-zipcode">{{ property.zipcode }}</h4>
      <h4 class="property-type">Type of Property: {{ property.type }}</h4>
      <h4 class="property-type">Beds: {{ property.beds }}</h4>
      <h4 class="property-type">Baths: {{ property.baths }}</h4>
      <h4 class="property-type">Rent: {{ property.rent }}</h4>
      <h4 class="property-type">Size: {{ property.size }} Sqft</h4>
      <p class="property-description">{{ property.description }}</p>

      <button
        v-if="!enableAdd && isLoggedIn && !applicationSubmitted"
        v-on:click.prevent="enableAdd = true"
        class="btn btn-primary"
        type="click"
      >
        Click Here If You Would Like To Apply
      </button>
      <span v-if="!isLoggedIn">
        <p>
          Please Register or Log In if you would like to apply for this property
        </p>
      </span>
      <span v-if="applicationSubmitted">
        <p>Your Application Has been submitted</p>
      </span>
      <form
      class="applicationForm"
        v-if="isLoggedIn && !isAdmin && enableAdd"
        v-on:submit.prevent="applyForProperty()"
      >
        <div class="mb-3">
          <label for="name" class="form-label">Please Enter Full Name</label>
          <input
            type="text"
            class="form-control"
            id="name"
            v-model.trim="application.name"
            required
            placeholder="Full Name"
          />
        </div>
        <div class="mb-3">
          <label for="address" class="form-label">Please enter your current address</label>
          <input
            type="text"
            class="form-control"
            id="address"
            v-model.trim="application.address"
            required
            placeholder="Current Address"
          />
        </div>
        <div class="mb-3">
          <label for="birthDate" class="form-label">Please enter your Date of Birth (in yyyy-mm-dd format)</label>
          <input
            type="text"
            class="form-control"
            id="birthDate"
            v-model.trim="application.birthDate"
            required
            placeholder="Date of Birth in yyyy-mm-dd format"
          />
        </div>
        <div class="mb-3">
          <label for="social" class="form-label">Please Enter your social security number</label>
          <input
            type="password"
            class="form-control"
            id="social"
            v-model.trim="application.social"
            required
            placeholder="Enter your Social Security Number"
          />
        </div>
        <div class="mb-3">
          <label for="salary" class="form-label">Please Enter annual salary</label>
          <input
            type="text"
            class="form-control"
            id="salary"
            v-model.number="application.salary"
            required
            placeholder="Yearly Salary"
          />
        </div>
        <div class="mb-3">
          <label for="phone" class="form-label">Please Enter your phone number</label>
          <input
            type="text"
            class="form-control"
            id="phone"
            v-model.trim="application.phoneNumber"
            required
            placeholder="Phone Number"
          />
        </div>
        <div class="mb-3">
          <label for="email" class="form-label">Please Enter your email address</label>
          <input
            type="text"
            class="form-control"
            id="email"
            v-model.trim="application.email"
            required
            placeholder="Email Address"
          />
        </div>
        <div>
          Do you have any Pets?
          <input type="radio" :value="true" v-model="application.hasPets" /> yes
          <input type="radio" :value="false" v-model="application.hasPets" /> no
        </div>
        <div class="optionsbuttons">
          <button type="submit" class="btn btn-success">Submit</button>
          <button
            type="cancel"
            class="btn btn-success cancelButton"
            v-on:click.prevent="enableAdd = false"
          >
            Cancel
          </button>
        </div>
      </form>
    </section>
  </div>
</template>
<script>
import ApplicationService from "../services/ApplicationService.js";

export default {
  name: "property-details",
  props: {
    property: Object,
  },
  data() {
    return {
      enableAdd: false,
      application: {
        name: "",
        social: "",
        birthDate: "",
        address: "",
        hasPets: false,
        salary: "",
        phoneNumber: "",
        email: "",
        propertyid: -1,
      },
      applicationSubmitted: false,
      showError: false,
      errorMessage: "",
    };
  },
  methods: {
    applyForProperty() {
      this.application.propertyid = this.property.id;
      console.log(this.application);
      ApplicationService.submitApplication(this.application)
        .then((response) => {
          const newItem = response.data;
          console.log(newItem);

          this.application = {
            name: "",
            social: "",
            address: "",
            hasPets: false,
            salary: 0,
            phoneNumber: "",
            propertyid: -1,
          };
          this.enableAdd = false;
          this.applicationSubmitted = true;
        })
        .catch((response) => {
          console.error("Couldn't submit application", response);
          this.showError = true;
          this.error = "Couldn't sumbit application";
        });
    },
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
<style lang="scss">
.property-details {
  text-align: center;
  color: black;
  width: 100%;
  border: 5px solid #76bfed;
  padding: 10px;
  margin: auto;
  background-color: #A8DADC;
  float: left;
  
}
.property-background {
  height: 100vh;
  background-image: url("https://external-preview.redd.it/orB818nEmNCypKfxPNQSVxOFIg6q8iNsvYGwMgk6Irg.jpg?auto=webp&s=1e3519053e8c865fc82667770e58d0d9469343d9");
  background-size: cover;
  
}
.cancelButton{
    margin: 10px;
}
.applicationForm{
    
}
/* body {
    background-image: url("https://external-preview.redd.it/orB818nEmNCypKfxPNQSVxOFIg6q8iNsvYGwMgk6Irg.jpg?auto=webp&s=1e3519053e8c865fc82667770e58d0d9469343d9") ;
  } */
</style>