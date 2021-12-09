<template>

    <li
    class="list-group-item  justify-content-between align-items-center" v-if="properties.isAvailable == true">
  <div class="property-name">
    {{ properties.name }}
    
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