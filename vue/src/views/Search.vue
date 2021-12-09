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
export default {
    props:{
        addedProperties: Array,
    },

    methods:{
    searchProperties(addedProperties){
        return this.addedProperties.filter(item => item.zipcode== addedProperties.zipcode && item.beds ==addedProperties.beds && item.baths == addedProperties.baths);
    }
    }

}
</script>

<style>
form {
display: flex;
flex-direction: column;

}
input{
    width: 35%;
   margin-bottom: 10px;
}
label{
    display:flex;
}

</style>