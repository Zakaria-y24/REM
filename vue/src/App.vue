<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app">
    <!-- If you start to get random styling you don't like, remove container from this div -->
    <nav id="nav" class="navbar navbar-expand-md">
      <div class="container-fluid">
        <router-link
              tag="button"
              class="nav-link"
              v-bind:to="{ name: 'home' }"
            >
          <img src="../images/rem-logo.png" class="logo" />
            </router-link>
        <div class="collapse navbar-collapse">
        <ul class="navbar-nav ms-auto">
          <li class="nav-item">
            <router-link
              tag="button"
              class="nav-link"
              v-bind:to="{ name: 'home' }"
            >
              Home
            </router-link>
          </li>
          <li class="nav-item">
            <router-link
              tag="button"
              class="nav-link"
              v-bind:to="{ name: 'search' }"
            >
              Search
            </router-link>
          </li>
          <li class="nav-item">
          <router-link
            tag="button"
            v-if="isLoggedIn && isAdmin"
            class="nav-link"
            v-bind:to="{ name: 'AddPropertyView' }"
          >
            Add A Property
          </router-link>
          </li>
          <li class="nav-item">
          <router-link
            tag="button"
            v-if="isLoggedIn && isAdmin"
            class="nav-link"
            v-bind:to="{ name: 'ManageProperties' }"
          >
            My Properties
          </router-link>
          </li>
          <li class="nav-item">
          <router-link
            tag="button"
            v-if="isLoggedIn && !isAdmin"
            class="nav-link"
            v-bind:to="{ name: 'MyApplicationsView' }"
          >
            My Applications
          </router-link>
          </li>
          <li class="nav-item">
          <router-link
            tag="button"
            v-if="isLoggedIn && isAdmin"
            class="nav-link"
            v-bind:to="{ name: 'ManagerApplicationsView' }"
          >
            Manage Applications
          </router-link>
          </li>
          <li class="nav-item">
          <router-link
            v-if="isLoggedIn && isAdmin"
            class="nav-link"
            v-bind:to="{ name: 'Data' }"
          >
            View Data
          </router-link>
          </li>
          <li class="nav-item">
          <router-link
            class="nav-link"
            tag="button"
            v-bind:to="{ name: 'register' }"
            v-if="!$store.state.token"
            >&nbsp;&nbsp;Register</router-link
          >
          </li>
          <li class="nav-item">
          <router-link
            class="nav-link"
            tag="button"
            v-bind:to="{ name: 'login' }"
            v-if="!$store.state.token"
          >
            &nbsp;&nbsp;Login
          </router-link>
          </li>
          <li class="nav-item">
          <router-link
            class="nav-link"
            tag="button"
            v-bind:to="{ name: 'logout' }"
            v-if="$store.state.token"
          >
            &nbsp;&nbsp;Logout
          </router-link>
          </li>
        </ul>
        </div>
      </div>
    </nav>

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
};
</script>

<!-- Application-Wide Styles go here. 
     Any valid CSS or SCSS is allowable here. See https://sass-lang.com/documentation/style-rules for info on SCSS -->
<style lang="scss">
@import "./styles/colors.scss";

// Import the bootstrap styles. If you want to override Bootstrap colors, it needs to happen above this line
@import "../node_modules/bootstrap/scss/bootstrap";

// Your custom styles go below this point
#app {
  height: 100vh;
}
template {
  margin-top: 5px;
}

.logo {
  width: 100px;
}

 .nav-link {
  border: none;
  color: #1D3557;
  background-color: #f4f4f4;
  padding: 0 2rem;
  text-decoration: none;
  font-size: 1.25rem;
 }


.navbar {
    height: 100px;
    background-color: #f4f4f4;
}
</style>