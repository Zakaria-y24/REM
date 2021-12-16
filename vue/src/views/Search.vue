<template>
  <section>
    <h2 class="search-header"> Search for Apartments</h2>
    <form id ="searchForm" v-on:submit.prevent="searchProperties()">
        <label for="zipcode"> Zipcode </label>
        <input class="input" type = "text" id = "zipcode" v-model.number="zipcode" /> 

        <label class="lable" for = "beds"> Beds</label>
        <input class="input"  type = "text" id = "beds" v-model.number="beds" /> 

        <label for="baths"> Bath </label>
        <input class="input" type = "text" id = "baths" v-model.number="baths"/>

         <button  type="submit" class="btn btn-success">
            Submit
        </button>

    </form>
     <div class="d-flex p-2 justify-content-around" v-show="true">
        <div class="row gap-5">
          <properties-list
            v-for="properties of properties"
            v-bind:key="properties.id"
            v-bind:properties="properties" />
          
        </div>
     </div>
       
    <div class="d-flex cta justify-content-center">
      <p class="h4 mb-2 text-center align-self-center">Interested in viewing more properties? <router-link :to="{ name: 'register' }">Register for an account today!</router-link></p>
     </div>
</section>
</template>

<script>
import PropertiesList from "../components/PropertiesList.vue";
import PropertiesService from "../services/PropertyService.js";

export default {
    components:{
        PropertiesList,
       
       
    },
    props: {
        properties: Array,
    },
    data(){
        return {
    
     zipcode: '',
     beds: '',
     baths:'',
        };
    
    },
  

    methods:{
       created() {
    PropertiesService.getAllProperties()
      .then((response) => {
        this.properties = response.data;
      })
      .catch((response) => {
        console.error("could not get properties", response);
      });
  },

    //       searchProperties(){
    //          let zipcode = document.getElementById("zipcode");
    //          let beds = document.getElementById("beds");
    //          let baths = document.getElementById("baths");
        
    //          for(let i=0; i < this.properties.length; i++){
    //              if(this.properties.zipcode == zipcode && this.properties.beds >= beds && this.properties.baths >= baths){
    //                 return true;
    //              }
    //          }
    //       }
        
     }
    
}

</script>

<style>
.search-header {
    margin-top:15px;
}

/* #searchForm {
   display: flex;
   flex-direction: row;
   
} */

.btn {
    width: 25%;
    color: white;
}


</style>