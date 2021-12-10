<template>
  <li
    class="list-group-item list-group-item-dark d-flex justify-content-between align-items-center"
  > 
    Applicant Name: {{applications.name}}
    Application Number: {{ applications.applicantId }}
    Property Number: {{ applications.propertyId }}
    Application Satus: {{applications.status}}
    <span>
      Date You Applied: {{ applications.date }} Application Status: {{applications.status}}
    </span>
    <button class="btn btn-primary" type="click" >View Details Not implimented</button>
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