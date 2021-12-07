<template>
    <li
    class="list-group-item  justify-content-between align-items-center"
  >
    {{ properties.text }}
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
        properties: Object,
    }
}
</script>

<style>

</style>