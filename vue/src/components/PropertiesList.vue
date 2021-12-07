<template>

    <li
    class="list-group-item  justify-content-between align-items-center" v-if="properties.isAvailable == true">
  <div class="property-name">
    {{ properties.name }}
  </div>
  <div class="property-address">
    {{properties.address}}

  </div>
    

    <span
      v-bind:class="{
        
      }"
    >
      
    </span>
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
  li div.property-name {
    background-color: red;
    flex-shrink: inherit;
  }
</style>