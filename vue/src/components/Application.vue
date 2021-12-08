<template>
  <div>
      <h2>Apply for Properties</h2>
      <form v-on:submit="applyForProperty()">
        <div class="mb-3">
            <label for="name" class="form-label"></label>
            <input type="text" class="form-control" id="name" 
                    v-model.trim="app.name"
                   required 
                   placeholder="Enter your Name">
        </div>
        <div class="mb-3">
            <label for="address" class="form-label"></label>
            <input type="text" class="form-control" id="address" 
                    v-model.trim="app.address"
                   required 
                   placeholder="Enter your current Address">
        </div>
        <div class="mb-3">
            <label for="salary" class="form-label"></label>
            <input type="text" class="form-control" id="salary" 
                    v-model.trim="app.salary"
                   required 
                   placeholder="What is your yearly Salary">
        </div>
        <div class="mb-3">
            <label for="phone" class="form-label"></label>
            <input type="text" class="form-control" id="phone" 
                    v-model.number="app.phone"
                   required 
                   placeholder="Enter Phone Number">
        </div>
        <div class="mb-3">
            <label for="property" class="form-label"></label>
            <input type="number" class="form-control" id="property" 
                    v-model.trim="app.property"
                   required 
                   placeholder="Enter Property Number">
        </div>
                <div>
            Do you have any Pets?
        <input type="radio" :value="true" v-model="app.hasPets"> yes
        <input type="radio" :value="false" v-model="app.hasPets"> no
        </div>
          <button type="submit" class="btn btn-success">
              Submit
          </button>
         </form>
  </div>
</template>

<script>
import ApplicationService from '../services/ApplicationService.js'

export default {
    props: {
        app: Object,
    },
    data() {
        return {

            application: {
                name: '',
                address: '',
                hasPets: false,
                salary: '',
                phone: '',
                property: 0
            },
            showError: false,
            errorMessage: '',
        }
    },
    methods: {
        applyForProperty() {
            ApplicationService
            .submitApplication(this.application)
            .then(response => {
                const newItem = response.data;
                this.application.push(newItem);

                this.application = {
                name: '',
                address: '',
                hasPets: false,
                salary: 0,
                phone: '',
                property: 0
                }
        })
            .catch(response => {
                console.error("Couldn't submit application", response)
                this.showError = true;
                this.error = "Couldn't sumbit application"
            })
        }
    }

    
}


</script>

<style>

</style>