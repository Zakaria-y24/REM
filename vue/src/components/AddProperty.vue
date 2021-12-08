<template> 
  <div>
      <h4>Add Property</h4>
       <form v-on:submit.prevent="addNewProperty()">
        <div class="mb-3">
            <label for="street" class="form-label"></label>
            <input type="text" class="form-control" id="street" 
                    v-model.trim="newProperty.Street"
                   required 
                   placeholder="Enter address">
        </div>
        <div class="mb-3">
            <label for="city" class="form-label"></label>
            <input type="text" class="form-control" id="city" 
                    v-model.trim="newProperty.City"
                   required 
                   placeholder="Enter City">
        </div>
        <div class="mb-3">
            <label for="state" class="form-label"></label>
            <input type="text" class="form-control" id="state" 
                    v-model.trim="newProperty.State"
                   required 
                   placeholder="Enter State">
        </div>
        <div class="mb-3">
            <label for="zipcode" class="form-label"></label>
            <input type="text" class="form-control" id="zipcode" 
                    v-model.number="newProperty.Zipcode"
                   required 
                   placeholder="Enter Zipcode">
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
        <div>
            Is the Property Available to Rent?
        <input type="radio" :value="true" v-model="newProperty.isAvailable"> yes
        <input type="radio" :value="false" v-model="newProperty.isAvailable"> no
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
props:{
    properties: Array
},
data() {
        return {
            
            newProperty: {
                Street: '',
                City: '',
                State: '',
                Zipcode: '',
                Name: '',
                Beds: '',
                Baths: '',
                Size: '',
                isAvailable: false

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
                const newItem = response.data;
                this.properties.push(newItem);
                
                this.newProperty = {
                Street: '',
                City: '',
                State: '',
                Zipcode: '',
                Name: '',
                Beds: '',
                Baths: '',
                Size: '',
                isAvailable: false
                }
        })
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