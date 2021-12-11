<template>
<div class="background d-flex justify-content-between">
  <div id="login" class="text-center">
    <form class="form-signin " @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-bold">Please Sign In</h1>
      <div class="form-group">
        <router-link :to="{ name: 'register' }">Need an account?</router-link>
      </div>
      
      <!-- conditions-->
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div class="alert alert-danger" role="alert" v-if="networkError">
        Network error!
      </div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration">
        Thank you for registering, please sign in.
      </div>
       <!-- end conditions-->

      <div class="form-group">
        <label for="username" class="form-label">Username</label>
        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus />
      </div>
      <div class="form-group ">
       <label for="password" class="form-label">Password</label>

        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required />
      </div>
      <button class="btn btn-primary bg-danger border-danger" type="submit">Sign in</button>
    </form>
  </div>
  <div class="image d-flex justify-content-center">
  <h2 class="align-self-center">Welcome Back</h2>
  </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
      networkError: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push({ name: "home" });
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response == null || response.status === 500) {
            this.networkError = true;
          }

          else if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>
<style scoped>
body {
  height: 100vh;
  width: 100vw;
}
h1 {
  color: #333;
}
.background{
  box-sizing: content-box;
  margin: 0 auto;
  padding: 0;
 height: 50vh;
  background-color: #F4F4F4;
  color: #1D3557;
  width: 100vw;
}
.image{
  background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)),
    url(../../images/login-img.jpg);
  width: 50vw;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  color: white;
}
input{
  width: 50vw;
  margin: 0 auto;
  border: 1px solid #457B9D;
}

.form-group{
  padding-left: 1rem;
  padding-right: 1rem;
}
</style>