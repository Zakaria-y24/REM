<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app"> <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav" class="bg-white">
      <router-link tag="button" class="nav-item" v-bind:to="{ name: 'home' }">
        <i class="fas fa-home"></i> <!-- This is a font awesome icon -->
        Home 
      </router-link> 
      <router-link tag="button" class="nav-item" v-bind:to="{name:'search'}">
        Search  
      </router-link> 
      <router-link tag="button" v-if="isLoggedIn && isAdmin" class="nav-item" v-bind:to="{name:'AddPropertyView'}">
       Add A Property  
      </router-link>
      <router-link tag="button" v-if="isLoggedIn && isAdmin" class="nav-item" v-bind:to="{name:'ManageProperties'}">
        My Properties  
      </router-link>  
      <router-link tag="button" v-if="isLoggedIn && !isAdmin" class="nav-item" v-bind:to="{name:'MyApplicationsView'}">
        My Applications  
      </router-link> 
      <router-link tag="button" v-if="isLoggedIn && isAdmin" class="nav-item" v-bind:to="{name:'ManagerApplicationsView'}">
        Manage Applications  
      </router-link>

       <router-link v-if="isLoggedIn && isAdmin" class="nav-item" v-bind:to="{name:'Data'}">
       | View Data 
      </router-link>  <router-link
        class="nav-item"
        tag="button" v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token">&nbsp;|&nbsp;Register</router-link>
      <router-link
        class="nav-item"
        tag="button" v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token">
        &nbsp;&nbsp;Login
      </router-link>
      <router-link
        class="nav-item"
        tag="button" v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token">
        &nbsp;&nbsp;Logout
      </router-link>
     
    </div>
    
    <router-view />
    </div>
</template>

<script>
export default {
  computed: {
    isLoggedIn() {
      return this.$store.state.token;
    },
    isAdmin() {
      return this.$store.state.user && this.$store.state.user.role === "admin";
    },
  },
}
</script>

<!-- Application-Wide Styles go here. 
     Any valid CSS or SCSS is allowable here. See https://sass-lang.com/documentation/style-rules for info on SCSS -->
<style lang="scss">

@import './styles/colors.scss';

// Import the bootstrap styles. If you want to override Bootstrap colors, it needs to happen above this line
@import '../node_modules/bootstrap/scss/bootstrap';

// Your custom styles go below this point
template{
  margin-top:5px;
}
#nav {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  align-content: center;

  
 
}
.nav-item {
  background-color: $dark; 
  border-radius: 5px;
  color: white;
  padding: 10px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
}
</style>