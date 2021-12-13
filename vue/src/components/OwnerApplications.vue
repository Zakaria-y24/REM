<template>

  <li
    class="list-group-item list-group-item-dark d-flex justify-content-between align-items-center"
  > 
    Applicant Name: {{applications.name}}
    Application Number: {{ applications.applicantId }}
    Property Number: {{ applications.propertyId }}
    Application Satus: {{applications.status}}
    <span>
      Date Applied: {{ applications.date }} Application Status: {{applications.status}}
    </span>
    <span v-if="viewDetails">

      Applcant BirthDate: {{applications.birthDate}}
      Applcant Email: {{applications.email}}
      Applcant PhoneNumber: {{applications.phone}}
      Applcant Salary: {{applications.salary}}
      Applcant Social: {{applications.social}}
      Applcant Current Address: {{applications.address}}
      Applcant BirthDate: {{applications.birthDate}}
      <button class="btn btn-primary" v-on:click="viewDetails = false" type="button" >Show Less</button>
      
    </span>
    <button class="btn btn-primary" v-if="!viewDetails" v-on:click="viewDetails = true" type="button" >View Details</button>
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
          propertyAddress: '',
          applicationStatus: '',
          salary: '',
          email: '',
          phone:'',
          hasPets: false,
          birthDate: '',
          date: '',
          currentAddress: '',

        },
        viewDetails: false

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