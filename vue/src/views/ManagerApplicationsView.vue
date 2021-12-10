<template>
<div>
<section class="applications">
  <owner-applications
            v-for="applications of applications"
            v-bind:key="applications.id"
            v-bind:applications="applications"
          />
</section>
</div>
</template>

<script>
import OwnerApplications from '../components/OwnerApplications.vue';
import ApplicationService from '../services/ApplicationService.js';

export default {
    name: 'ManagerApplicationsView',
    data(){
        return {
            applications: [],
            
        }
    },
    components: {
        OwnerApplications
    },
    created() {
      ApplicationService
      .getApplicationsForOwner()
      .then(response => {
        this.applications = response.data;
      })
      .catch(response => {
        console.error("could not get properties", response);
      });
    },
    /*computed: {
        Application() {
            if(!this.applications){
                return undefined;
            }
            return this.applications.find(p => p.id == this.$route.params.id);
            
        }
    }*/
}
</script>
<style >

</style>