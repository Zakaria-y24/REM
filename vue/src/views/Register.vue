<template>
<div class="row d-flex align-items-center">
  <div class="col-6 pl-0">
    <div id="registerCarousel" class="carousel slide" data-ride="carousel">
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img class="d-block img-fluid" src="../../images/register1.jpg" alt="First slide">
        </div>
        <div class="carousel-item">
          <img class="d-block img-fluid" src="../../images/register2.jpg" alt="Second slide">
        </div>
        <div class="carousel-item">
          <img class="d-block img-fluid" src="../../images/register3.jpg" alt="Third slide">
        </div>
      </div>
    </div>
  </div>
  <div class="col-6">
    <div id="register" class="text-center mt-3">
    <form class="form-register " @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="form-group">
        <router-link :to="{ name: 'login' }">Have an account?</router-link>
      </div>
      <div class="form-group d-flex flex-column">
        <label for="username" class="form-label align-self-lg-start">Username</label>
        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus />
      </div>
              <div class="form-group d-flex flex-column">
                <label for="password" class="form-label align-self-lg-start">Password</label>
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required />
      </div>
        <div class="form-group d-flex flex-column">
        <label for="confirmPassword" class="form-label align-self-lg-start">Confirm Password</label>
        <input
          type="password"
          id="confirmPassword"
          class="form-control"
          placeholder="Confirm Password"
          v-model="user.confirmPassword"
          required />
      </div>
      <div>
        Are you a Property Manager?
      <input type="radio" :value="'admin'" v-model="user.role"> Yes
      <input type="radio" :value="'user'" v-model="user.role"> No
      </div>
      <button class="btn btn-primary bg-danger border-danger mt-3" type="submit">
        Create Account
      </button>
    </form>
  </div>
  </div>
</div>
  
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: '',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                name: 'login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style scoped>

html{
  height: 100vh;
  width: 100vw;
  margin:0;
  padding:0;
}

.carousel .item > img {
  max-height: 100%;

}
h3 {
  color: #333;
}

input {
  margin: 0 auto;
  border: 1px solid #457b9d;
}

#registerCarousel {
  overflow: hidden;
  
}

.row{
  border-top: 0.5rem solid #1D3557;
  margin: 0 auto;
}

</style>
