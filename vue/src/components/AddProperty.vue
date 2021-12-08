<template> 
  <div>
      <h4>Add Property</h4>
       <form v-on:submit.prevent="addNewProperty()">
        <div class="mb-3">
            <label for="address" class="form-label"></label>
            <input type="text" class="form-control" id="address" 
                    v-model.trim="newProperty.Address"
                   required 
                   placeholder="Enter address">
        </div>
        <div class="mb-3">
            <label for="name" class="form-label"></label>
            <input type="text" class="form-control" id="name" 
                    v-model.trim="newProperty.Name"
                   required 
                   placeholder="Enter Property Name">
        </div>
        <div class="mb-3">
            <label for="beds" class="form-label"></label>
            <input type="text" class="form-control" id="beds" 
                    v-model.number="newProperty.Beds"
                   required 
                   placeholder="Enter Number of Beds">
        </div>
        <div class="mb-3">
            <label for="baths" class="form-label"></label>
            <input type="text" class="form-control" id="baths" 
                    v-model.number="newProperty.Baths"
                   required 
                   placeholder="Enter Number of Baths">
        </div>
        <div class="mb-3">
            <label for="size" class="form-label"></label>
            <input type="text" class="form-control" id="size" 
                    v-model.number="newProperty.Size"
                   required 
                   placeholder="Enter Size of Property in Sqft">
        </div>
       

        <button type="submit" class="btn btn-success">
            Submit
        </button>
      </form>
  </div>
</template>



<script>

import PropertyService from '../services/PropertyService.js'

export default {
props: {
        properties: Object,
    },
data() {
        return {
            newProperty: {
                Address: '',
                Name: '',
                Beds: '',
                Baths: '',
                Size: '',
                isAvailable: ''

            },
            showError: false,
            errorMessage: '',
        }
    },
    methods: {
        addNewProperty() {
            PropertyService
            .addProperty(this.newProperty)
            .then(response => {

                if (this.newProperty.isAvailable == "true"){
                    this.newProperty.isAvailable = true;
                }
                else{
                    this.newProperty.isAvailable = false;

                const newItem = response.data;
                this.properties.push(newItem);

                this.newProperty = {
                Address: '',
                Name: '',
                Beds: '',
                Baths: '',
                Size: '',
                isAvailable: ''
                }
            }})
            .catch(response => {
                console.error("Couldn't add property", response)
                this.showError = true;
                this.errorMessage = "Couldn't add property please try again"
            })
        }
    }
}
</script>

<style>

</style>