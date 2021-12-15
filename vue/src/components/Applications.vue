<template>
  <li
    class="list-group-item list-group-item-dark d-flex justify-content-between align-items-center"
  >
    Application Number: {{ applications.applicantId }}
    Property Number You've Applied To:<router-link v-bind:to="{ name: 'PropertyInfo', params: {id: applications.propertyId}}">{{ applications.propertyId }}</router-link>
    <span>
      Date You Applied: {{ applications.date }} Application Status: {{applications.status}}
    </span>
  </li>
</template>

<script>
export default {
    props: {
        applications: Object,
    },
    
};
</script>

<style>
</style>