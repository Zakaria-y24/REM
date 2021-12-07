<template>
    <li
    class="list-group-item  justify-content-between align-items-center" v-if="properties.isAvailable = true"
  >
    {{ properties.name }}
    {{properties.address}}
    {{properties.id}}
    {{properties.isAvailable}}
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

</style>