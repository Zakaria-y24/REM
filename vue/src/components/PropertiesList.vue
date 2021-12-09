<template>

    <!-- <li
    class="list-group-item  justify-content-between align-items-center" v-if="properties.isAvailable == true">
  <div class="property-name">
    {{ properties.name }}
    
  </div>
  <div class="property-address">
    {{properties.street}}
    {{properties.city}}
    {{properties.zipcode}}

  </div>
    

    <span
      v-bind:class="{
        
      }"
    >
      
    </span>
  </li> -->
  
  <div class="card text-left" v-if="properties.isAvailable == true">
  
  <img src="../../images/image-placeholder.jpg" class="card-img-top">
  <div class="card-body">
    <p class="card-text">
      {{ properties.name }}</p>
    <p class="card-text"> 
      {{properties.street}}
    {{properties.city}}
    {{properties.zipcode}}
    </p>
  </div>
</div>

</template>

<script>

export default {
    props: {
        properties: Object,
    }
}
</script>

<style>
 .card {
  border: none;
  border-radius: 0;
  border-bottom: 3px solid #457B9D;
  margin-bottom: 2rem;
  width: 15rem;
  padding: 0;
}
.card-body{
  padding: 1rem 0 1rem 0;
}
</style>