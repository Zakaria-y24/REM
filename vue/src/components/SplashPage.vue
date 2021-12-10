<template>
  <div class="tag-container d-flex justify-content-center">
    <div class="wrapper align-self-center">
      <h1 class="text-white">Find your next</h1>
      <div class="words text-white align-self-center">
        <span>home</span>
        <span>property</span>
        <span>apartment</span>
        <span>tenant</span>
        <span>family</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.tag-container {
  background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)),
    url(../../images/home-splash.jpg);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  height: 40vh;
}
h1 {
  font-size: 4rem;
}

.wrapper {
  /* background-color: red; */
  box-sizing: content-box;
  display: flex;
  height: 80px;
   overflow: hidden;
}

.words {
  font-size: 4rem;
  overflow: hidden;
  font-weight: 300;
  
}

span {
  display: block;
  padding-left: 20px;
  height: 100%;
  /* border: 1px solid orange; */
  animation: spin_words 7s infinite;
  
}
@keyframes spin_words {
  0% {
    transform: translateY(275%);
  }
  
  10% {
    transform: translateY(275%);
  }
  25% {
    transform: translateY(200%);
  }
  35% {
    transform: translateY(100%);
  }
  45% {
    transform: translateY(102%);
  }
  55% {
    transform: translateY(0%);
  }
  65% {
    transform: translateY(2%);
  }
  75%{
    transform: translateY(-100%);
  }

  85%{
    transform: translateY(-98%);
  }
  
  95% {
    transform: translateY(-200%);
  }
  100% {
    transform: translateY(-198%);
  }
}
</style>