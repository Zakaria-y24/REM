<template>

  <div class="card text-left" v-if="properties.isAvailable == true">
  
  <img src="../../images/image-placeholder.jpg" class="card-img-top">
  <div class="card-body">
    <p class="card-text">
      </p> <router-link v-bind:to="{name: 'PropertyInfo', params: { id: properties.id}}">{{ properties.name }}</router-link>
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
  border-bottom: 3px solid #E63946;
  cursor: pointer;
}
.card-body{
  padding: 1rem 0 1rem 0;
}
</style>