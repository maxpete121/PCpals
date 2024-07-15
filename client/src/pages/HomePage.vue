<template>
<section class="container-fluid w-100">
  <div class="row justify-content-center mt-2">
    <div class="p-2 d-flex justify-content-center">
        <div class="warning-notification d-flex align-items-lg-center">
            <h4 class="text-warning me-1 mt-lg-2"><i class="mdi mdi-information-outline"></i></h4>
            <p class="notification-text">WARNING: Computers can not yet be purchased as this website is currently in development. Please submit any issues or bugs via support ticket <router-link :to="{ name: 'Contact' }" >here</router-link>.</p>
        </div>
    </div>
  </div>
  <div class="row justify-content-center mb-4 mt-2 pb-2">
    <div class="col-lg-8 col-11 justify-content-center mt-1 text-center">
      <h3 class="fst-italic"></h3>
      <div class="d-flex flex-column flex-lg-row justify-content-center">
        <div class="text-center top-home-info mt-3 mb-lg-3 me-lg-4 pb-2 bg-white d-flex flex-column align-self-center">
          <h4>Build a PC</h4>
          <img class="img-browse d-flex align-self-center" src="https://storage-asset.msi.com/global/picture/article/seo_168231685364461e357a5f07.82597235.jpeg" alt="">
          <h6 class="mt-3">Login or create an account to access our PC Builder.</h6>
          <h6>Set the builder to either pro or beginner.</h6>
          <h6>Build the PC of your dreams!</h6>
          <div class="text-center">
            <button @click="editBuildPage()" class="home-btn mt-3" v-if="account.id">Create a build!</button>
            <button @click="loginHome()" class="home-btn mt-3" v-if="!account.id">Login/Create Account</button>
          </div>
        </div>
        <div class="text-center top-home-info mt-3 mb-lg-3 ms-lg-4 pb-2 bg-white d-flex flex-column align-self-center">
          <h4>Browse PCs</h4>
          <img class="img-browse d-flex align-self-center" src="https://media.cnn.com/api/v1/images/stellar/prod/200630133939-build-3-1.jpg?q=w_4032,h_3024,x_0,y_0,c_fill" alt="">
          <h6 class="mt-3">Browse builds made and suggested by us!</h6>
          <h6>Buy builds made by other customers!</h6>
          <h6>Save builds your interested in for later!</h6>
          <div class="text-center">
            <button @click="goToBrowseBuilds()" class="home-btn mt-3">Browse User Builds</button>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="row justify-content-center bg-dark pt-2 pt-lg-0 container-builds">
    <div class="col-lg-5 col-12 me-lg-4 mt-lg-4">
      <div class="text-center">
        <h4 class="title-font text-light">Our Suggestions</h4>
      </div>
      <div class="w-100 d-flex flex-column pt-2 pb-3 align-items-center bg-white section-build ps-2 pe-2">
        <div v-for="suggestion in suggestions" class="">
          <SuggestionBuildComponent :suggestedBuild="suggestion"/>
        </div>
      </div>
    </div>
    <div class="col-lg-5 mt-lg-0 mt-4 col-12 ms-lg-4 mt-lg-4">
      <div class="text-center mt-lg-0">
        <h4 class="title-font text-light">Recent Builds</h4>
      </div>
      <div class="w-100 bg-white align-items-center section-build d-flex flex-column align-items-center ps-2 pe-2 pt-2 pb-3">
        <div class="d-flex justify-content-center" v-for="recentBuild in recentBuilds">
          <HomeBuildComponent :recentBuild="recentBuild"/>
        </div>
      </div>
    </div>
  </div>
  <div style="display: none;" class="row pb-4 pt-4 justify-content-center bg-dark">
    <div class="col-9 d-flex flex-column flex-lg-row justify-content-lg-evenly justify-content-center mt-4 mb-3">
      <div class="text-center main p-3 info-top mt-lg-1 mt-3 d-flex flex-column align-self-center">
        <h3 class="title-style">Our Goal</h3>
        <p>Our goal is to bring desktop gaming to the public, at affordable prices.</p>
        <button class="home-btn">Learn More</button>
      </div>
      <div class="text-center main p-3 ms-lg-4 me-lg-4 info-top mt-lg-1 mt-3 d-flex flex-column align-self-center">
        <h3 class="title-style">Speed Scores</h3>
        <p>Speed scores are here to give you a general sense of your PC's power.</p>
        <button class="home-btn ms-4 me-4">Learn More</button>
      </div>
      <div class="text-center main p-3 info-top mt-lg-1 mt-3 d-flex flex-column align-self-center">
        <h3 class="title-style">How we work</h3>
        <p>Submit a cleaning ticket to our team to get your PC looking brand new!</p>
        <button class="home-btn">Learn More</button>
      </div>
    </div>
  </div>
  <BuildDetailsModal id="BuildModal"/>
</section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { pcBuildService } from '../services/PcBuildService';
import HomeBuildComponent from '../components/HomeBuildComponent.vue';
import ReviewModal from '../components/ReviewModal.vue';
import SuggestionBuildComponent from '../components/SuggestionBuildComponent.vue';
import { suggestionService } from '../services/SuggestionService';
import { AuthService } from '../services/AuthService';
import { router } from '../router';
import BuildDetailsModal from '../components/BuildDetailsModal.vue';
export default {
  setup() {
    onMounted(()=>{
      getSharedBuilds()
      getSuggestions()
    })
    
    let useAccount = computed(()=> AppState.account)
    async function getSharedBuilds(){
      await pcBuildService.getSharedBuilds()
    }

    async function getSuggestions(){
      await suggestionService.getSuggestions()
    }

    async function loginHome(){
      AuthService.loginWithPopup()
    }

    async function editBuildPage(){
      router.push({ path: '/MyBuilds'})
    }

    async function goToBrowseBuilds(){
      router.push({ path: '/BrowseBuilds'})
    }
    return {
      goToBrowseBuilds,
      editBuildPage,
      loginHome,
      recentBuilds: computed(()=> AppState.recentBuilds),
      suggestions: computed(()=> AppState.suggestedBuilds),
      account: computed(()=> AppState.account)
    }
  }, components: {HomeBuildComponent, ReviewModal, SuggestionBuildComponent, BuildDetailsModal}
}
</script>

<style scoped lang="scss">
    .warning-notification{
        background-color: rgba(255, 238, 1, 0.438);
        padding: 4px;
    }

    .notification-text{
        margin: 0;
        font-size: small;
    }

@media screen and (min-width: 576px) {
  .img-resize{
    max-height: 300px;
    max-width: 600px;
  }

  .top-home-info{
  outline: solid 2px purple;
  border-radius: 10px;
  width: 550px;
  box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.582);
}

.img-browse{
  height: 220px;
  width: 340px;
  box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.24);
}

.section-build{
  outline: solid 2px purple;
  box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.171);
  overflow-y: scroll;
  height: 345px;
}
}
@media screen and (max-width: 576px) {
  .img-resize{
    max-height: 100px;
    max-width: 300px;
  }
  .img-browse{
  height: 150px;
  width: 250px;
}
.top-home-info{
  outline: solid 2px purple;
  border-radius: 10px;
  width: 300px;
  box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.582);
  padding-left: 15px;
  padding-right: 15px;
  padding-top: 15px;
}

.section-build{
  outline: solid 2px purple;
  box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.171);
  overflow-y: scroll;
  height: 530px;
}

.container-builds{
  box-shadow: -3px -3px -3px rgba(0, 0, 0, 0.205);
}

}

.title-font{
  font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
}

.main{
width: 250px;
}
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}


.home-btn{
  all: unset;
  padding-left: 8px;
  padding-right: 8px;
  padding-top: 4px;
  padding-bottom: 4px;
  border-radius: 10px;
  background-color: whitesmoke;
  outline: solid 2px purple;
  color: black;
}
.home-btn:hover{
  all: unset;
  padding-left: 8px;
  padding-right: 8px;
  padding-top: 4px;
  padding-bottom: 4px;
  outline: solid 2px purple;
  border-radius: 10px;
  background-color: rgb(221, 221, 221);
  color: black;
  cursor: pointer;
}

.info-top{
  background-color: rgba(128, 0, 128, 0.788);
  border-radius: 10px;
  padding: 5px;
  color: white;
  box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.432);
  width: 270px;
}

.info-top:hover{
  background-color: rgb(128, 0, 128);
  border-radius: 10px;
  padding: 5px;
  color: white;
  width: 270px;
}

.title-style{
  text-shadow: 3px 3px 3px black;
}
</style>
