<template>
    <li
    class="list-group-item  justify-content-between align-items-center"
  >
    {{ properties.Name }}
    <span
      v-bind:class="{
        id
      }"
    >
      
    </span>
  </li>
</template>

<script>

export default {
    props: {
        property: Object,
    }
}
</script>

<style>

</style>