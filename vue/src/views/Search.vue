<template>
  <section>
    <h2> Search for Apartments</h2>
    <form v-on:submit.prevent="searchProperties()">
        <label for="zipcode"> Zipcode </label>
        <input type = "text" id = "zipcode" /> 

        <label for = "beds"> Beds</label>
        <input type = "text" id = "beds" /> 

        <label for="baths"> Bath </label>
        <input type = "text" id = "baths" />

         <button type="submit" class="btn btn-success">
            Submit
        </button>

    </form>


</section>
</template>

<script>
import PropertyService from '../services/PropertyService.js'
export default {
    props:{
        addedProperties: Array,
    },
    zipcode: '',
    beds: '',
    baths:'',

    methods:{
    searchProperties(addedProperties){
        PropertyService.searchProperties(this.zipcode,this.beds, this.baths)
        .then(response => 
        {
            return response.filter(item => item.zipcode== addedProperties.zipcode && item.beds ==addedProperties.beds && item.baths == addedProperties.baths);
        })
        .catch(response => {
            console.error('Could not find properties', response)
        })
        
    }
    }

}
</script>

<style scoped>
h2 {
    margin-top:15px;
}
form {
display: flex;
flex-direction: column;
margin-left:50px;

}
input{
    width: 25%;
   margin-bottom: 10px;
   
}
label{
    display:flex;
}
button {
    width: 25%;
    color: white;
}
</style>