<template>

  <li
    class="list-group-item list-group-item-dark d-flex justify-content-between align-items-center"
  > 
    Applicant Name: {{applications.name}}
    Application Number: {{ applications.applicantId }}
    Property Number: {{ applications.propertyId }}
    Application Satus: {{applications.status}}
    <span>
      Date Applied: {{ applications.date }}
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
      <button class="btn btn-primary" v-on:click="acceptApplication" type="button" >Accept Application</button>
      <button class="btn btn-primary" v-on:click="viewDetails = false" type="button" >Deny Application</button>
    </span>
    <button class="btn btn-primary" v-if="!viewDetails" v-on:click="viewDetails = true" type="button" >View Details</button>
  </li>
</template>

<script>
import ApplicationService from '../services/ApplicationService.js'
import PropertyService from '../services/PropertyService.js'
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
    methods:{

      acceptApplication() {
        PropertyService.MakePropertyUnavailable(this.applications)
        .then((response) => {
          const newItem = response.data;
          console.log(newItem);
        })
        .catch((response) => {
          console.error("Couldn't update property", response);
          this.showError = true;
          this.errorMessage = "Couldn't update property please try again";
        });
    
      ApplicationService.ApproveApplication(this.applications)
        .then((response) => {
          const newItem = response.data;
          console.log(newItem);
        })
        .catch((response) => {
          console.error("Couldn't update application", response);
          this.showError = true;
          this.errorMessage = "Couldn't update application please try again";
        });
    
    },
    }
};
</script>

<style>
</style>