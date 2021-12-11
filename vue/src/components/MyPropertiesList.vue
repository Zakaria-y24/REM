<template>

  <div class="card text-left" >
  
 
  <img src="../../images/image-placeholder.jpg" class="card-img-top">
  <div class="card-body">
    <p class="card-text">
      </p> 
        {{ properties.name }}
    <p class="card-text"> 
      {{properties.street}}
    {{properties.city}}
    {{properties.zipcode}}
     <span v-if="properties.isAvailable == false">Not</span> Avaiabile 
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

<style scoped>
 .card {
  border: none;
  border-radius: 0;
  border-bottom: 3px solid #457B9D;
  margin-bottom: 2rem;
  width: 15rem;
  padding: 0;
}
.card:hover{
  border-bottom: 3px solid #76BFED;
  cursor: pointer;
}
.card-body{
  padding: 1rem 0 1rem 0;
}
a{
  text-decoration: none;
  color: #333;
}
</style>