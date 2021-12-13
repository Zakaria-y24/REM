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
    <button class="btn btn-primary" v-on:click="getApplications()" type="click" >View Details Not implimented</button>
  </li>
</template>

<script>
import ApplicationService from '../services/ApplicationService.js'
export default {
  
    props: {
        applications: Object,
    },
    data() {
      return {
        application: {
          name: '',
          applicationId: 0,
          propertyAddress: '',
          applicationStatus: '',
          salary: '',
          email: '',
          phone:'',
          hasPets: false,
          birthDate: ''
        }

      }

    },
    methods: {
     getApplications() {
       ApplicationService.getApplicationsForOwner()
    
       
     }
      
    }
};
</script>

<style>
</style>