<template>
  <section class="property details">
      <h1 class="property-name"> {{ property.name }} </h1>
      
      <h2 class="property-street"> {{ property.street }} </h2>
      <h2 class="property-city"> {{ property.city }} </h2>
      <h2 class="property-zipcode"> {{ property.zipcode }} </h2>
      <button v-if="!enableAdd && isLoggedIn && !applicationSubmitted" v-on:click.prevent="enableAdd = true;" class="btn btn-primary" type="click">Click Here If You Would Like To Apply</button>
      <span v-if="!isLoggedIn">
          <p>Please Register or Log In if you would like to apply for this property</p>
      </span>
      <span v-if="applicationSubmitted">
          <p>Your Application Has been submitted</p>
      </span>
      <form v-if="isLoggedIn && !isAdmin && enableAdd" v-on:submit.prevent="applyForProperty()">
        <div class="mb-3">
            <label for="name" class="form-label"></label>
            <input type="text" class="form-control" id="name" 
                    v-model.trim="application.name"
                   required 
                   placeholder="Enter your Name">
        </div>
        <div class="mb-3">
            <label for="address" class="form-label"></label>
            <input type="text" class="form-control" id="address" 
                    v-model.trim="application.address"
                   required 
                   placeholder="Enter your current Address">
        </div>
        <div class="mb-3">
            <label for="birthDate" class="form-label"></label>
            <input type="text" class="form-control" id="birthDate" 
                    v-model.trim="application.birthDate"
                   required 
                   placeholder="Enter Date of Birth">
        </div>
        <div class="mb-3">
            <label for="social" class="form-label"></label>
            <input type="text" class="form-control" id="social" 
                    v-model.number="application.social"
                   required 
                   placeholder="Enter your Social Security Number">
        </div>
        <div class="mb-3">
            <label for="salary" class="form-label"></label>
            <input type="text" class="form-control" id="salary" 
                    v-model.number="application.salary"
                   required 
                   placeholder="What is your yearly Salary">
        </div>
        <div class="mb-3">
            <label for="phone" class="form-label"></label>
            <input type="text" class="form-control" id="phone" 
                    v-model.trim="application.phoneNumber"
                   required 
                   placeholder="Enter Phone Number">
        </div>
        <div class="mb-3">
            <label for="email" class="form-label"></label>
            <input type="text" class="form-control" id="email" 
                    v-model.trim="application.email"
                   required 
                   placeholder="Enter Your Email Address">
        </div>
                <div>
            Do you have any Pets?
        <input type="radio" :value="true" v-model="application.hasPets"> yes
        <input type="radio" :value="false" v-model="application.hasPets"> no
        </div>
          <button type="submit" class="btn btn-success">
              Submit
          </button>
         </form>
  </section>
</template>
<script>
import ApplicationService from '../services/ApplicationService.js' 

export default {
    name: 'property-details',
    props: {
        property: Object
    },
     data() {
        return {
            enableAdd: false,
            application: {
                name: '',
                social: '',
                birthDate: '',
                address: '',
                hasPets: false,
                salary: '',
                phoneNumber: '',
                email: '',
                propertyid: -1
                
                

            },
            applicationSubmitted: false,
            showError: false,
            errorMessage: '',
        }
    },
    methods: {
        applyForProperty() {
            this.application.propertyid = this.property.id;
            console.log(this.application)
            ApplicationService
            .submitApplication(this.application)
            .then(response => {
                const newItem = response.data;
                console.log(newItem);

                this.application = {
                name: '',
                address: '',
                social: '',
                hasPets: false,
                salary: 0,
                phoneNumber: '',
                propertyid: -1
                }
                this.enableAdd = false;
                this.applicationSubmitted = true;
        })
            .catch(response => {
                console.error("Couldn't submit application", response)
                this.showError = true;
                this.error = "Couldn't sumbit application"
            })
        }
    },
    computed: {
        isLoggedIn() {
      return this.$store.state.token;
    },
    isAdmin() {
      return this.$store.state.user && 
             this.$store.state.user.role === 'admin';
        }
    }
}
</script>
<style>

</style>