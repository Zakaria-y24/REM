<template>
  <div class="my-component d-flex justify-content-center align-items-center">
    <div class="container">
      <div class="row h-100">
        <div class="col-12 col-lg-6 pb-2 pt-2">
          <div id="login" class="text-center">
            <form class="form-signin" @submit.prevent="login">
              <h1 class="h3 font-weight-bold">Please Sign In</h1>
              <div class="form-group">
                <router-link :to="{ name: 'register' }"
                  >Need an account?</router-link
                >
              </div>

              <!-- conditions-->
              <div
                class="alert alert-danger"
                role="alert"
                v-if="invalidCredentials"
              >
                Invalid username and password!
              </div>
              <div class="alert alert-danger" role="alert" v-if="networkError">
                Network error!
              </div>
              <div
                class="alert alert-success"
                role="alert"
                v-if="this.$route.query.registration"
              >
                Thank you for registering, please sign in.
              </div>
              <!-- end conditions-->

              <div class="form-group d-flex flex-column">
                <label for="username" class="form-label align-self-lg-start">Username</label>
                <input
                  type="text"
                  id="username"
                  class="form-control"
                  placeholder="Username"
                  v-model="user.username"
                  required
                  autofocus
                />
              </div>
              <div class="form-group d-flex flex-column">
                <label for="password" class="form-label align-self-lg-start">Password</label>

                <input
                  type="password"
                  id="password"
                  class="form-control"
                  placeholder="Password"
                  v-model="user.password"
                  required
                />
              </div>
              <button
                class="btn btn-primary bg-danger border-danger"
                type="submit"
              >
                Sign in
              </button>
            </form>
          </div>
        </div>
        <div class="img-container d-none d-lg-block col-lg-6 pr-0">
          
          <h2 style="position: absolute; left: 50%; top:50%; transform: translate(-50%, -50%);" class="text-white">Welcome Back</h2>
          <img src="../../images/login-img.jpg" class="img-fluid"/>
         
        </div>
      </div>
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
          } else if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>
<style scoped>

.my-component{
  height: 100vh;
  background-color:  #fff;
 
}

html,body{margin:0;padding:0;}




.container{
  background-color: #f4f4f4;
  border-left: 0.5rem solid #E63946;
} 

h1 {
  color: #333;
}

input {
  margin: 0 auto;
  border: 1px solid #457b9d;
}

.form-group {
  padding-left: 1rem;
  padding-right: 1rem;
}
</style>