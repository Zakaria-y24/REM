<template>
  <div class="card text-left" v-if="properties.isAvailable == true">
    
    
    <router-link
      v-bind:to="{ name: 'PropertyInfo', params: { id: properties.id } }"
    >
      <img src="../../images/1000.jpeg" class="card-img-top" />
      <div class="card-body">
        <p class="card-text"></p>
        {{ properties.name }}
        <p class="card-text">
          {{ properties.street }}
          {{ properties.city }}
          {{ properties.zipcode }}
        </p>
      </div>
    </router-link>
  </div>
</template>

<script>
export default {
  props: {
    properties: Object,
  },
  data(){
    return{
     
    }
  }
};
</script>

<style scoped>
.card {
  border: none;
  border-radius: 0;
  border-bottom: 3px solid #457b9d;
  margin-bottom: 2rem;
  width: 15rem;
  padding: 0;
}
.card:hover {
  border-bottom: 3px solid #76bfed;
  cursor: pointer;
}
.card-body {
  padding: 1rem 0 1rem 0;
}
a {
  text-decoration: none;
  color: #333;
}
</style>