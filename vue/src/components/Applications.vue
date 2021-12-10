<template>
  <li
    class="list-group-item list-group-item-dark d-flex justify-content-between align-items-center"
  >
    Application Number: {{ applications.applicantId }}
    Property Number You've Applied To: {{ applications.propertyId }}
    <span>
      {{ applications.date }}
    </span>
  </li>
</template>

<script>
export default {
    props: {
        applications: Object,
    }
};
</script>

<style>
</style>