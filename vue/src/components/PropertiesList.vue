<template>

    <li
    class="list-group-item  justify-content-between align-items-center" v-if="properties.isAvailable == true">
  <div class="property-name">
    <router-link v-bind:to="{name: 'PropertyInfo', params: { id: properties.id}}">{{ properties.name }}</router-link>
    
  </div>
  <div class="property-address">
    {{properties.street}}
    {{properties.city}}
    {{properties.zipcode}}
    

  </div>
  </li>
</template>

<script>

export default {
    props: {
        properties: Object,
    }
}
</script>

<style>
  div {
    text-align: center;
  }
</style>