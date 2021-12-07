<template>
    <li
    class="list-group-item  justify-content-between align-items-center"
  >
    {{ properties.name }}
    {{properties.address}}
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