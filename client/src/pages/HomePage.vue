<template>
<section class="container-fluid">
  <div class="row justify-content-center">
    <div class="col-8 justify-content-center mt-3 text-center">
      <h3 class="fst-italic">How it works?</h3>
      <div class="d-flex justify-content-center">
        <div class="text-center w-50">
          <h4>Build a PC</h4>
          <h6>Login or create an account to access our PC Builder.</h6>
          <h6>Set the builder to either pro or beginner.</h6>
          <h6>Build the PC of your dreams!</h6>
        </div>
        <div class="text-center w-50">
          <h4>Browse PCs</h4>
          <h6>Browse builds made and suggested by us!</h6>
          <h6>Buy builds made by other customers!</h6>
          <h6>Save builds your interested in for later!</h6>
        </div>
      </div>
    </div>
  </div>
  <div class="row justify-content-center mt-3 bg-dark pt-4">
    <div class="col-lg-5 col-11 section-build me-lg-4 d-flex flex-column align-items-center bg-white">
      <h4>Our Suggestions</h4>
      <div v-for="suggestion in suggestions" class="">
        <SuggestionBuildComponent :suggestedBuild="suggestion"/>
      </div>
    </div>
    <div class="col-lg-5 col-11 d-flex flex-column align-items-center section-build pt-1 pb-3 bg-white">
      <h4>Recent Builds</h4>
      <div class="d-flex justify-content-center" v-for="recentBuild in recentBuilds">
        <HomeBuildComponent :recentBuild="recentBuild"/>
      </div>
    </div>
  </div>
  <div class="row pb-4 pt-4 justify-content-center bg-dark">
    <div class="col-9 d-flex justify-content-evenly mt-2 mb-3">
      <div class="text-center main ps-2 pe-2 info-top">
        <h3 class="title-style">Find a PC</h3>
        <p>Browse our selection of high end gaming PCs, or check out other users builds.</p>
        <button class="home-btn">Browse</button>
      </div>
      <div class="text-center main ms-4 me-4 info-top">
        <h3 class="title-style">Build your own PC</h3>
        <p>Make an account or sign in to create a PC build and share it with others!</p>
        <button class="home-btn ms-4 me-4">Pc Builder</button>
      </div>
      <div class="text-center main info-top">
        <h3 class="title-style">Schedule a clean</h3>
        <p>Submit a cleaning ticket to our team to get your PC looking brand new!</p>
        <button class="home-btn">Get a clean</button>
      </div>
    </div>
  </div>
</section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import { pcBuildService } from '../services/PcBuildService';
import HomeBuildComponent from '../components/HomeBuildComponent.vue';
import ReviewModal from '../components/ReviewModal.vue';
import SuggestionBuildComponent from '../components/SuggestionBuildComponent.vue'
import { suggestionService } from '../services/SuggestionService';
export default {
  setup() {
    onMounted(()=>{
      getSharedBuilds()
      getSuggestions()
    })

    async function getSharedBuilds(){
      await pcBuildService.getSharedBuilds()
    }

    async function getSuggestions(){
      await suggestionService.getSuggestions()
    }
    return {
      recentBuilds: computed(()=> AppState.recentBuilds),
      suggestions: computed(()=> AppState.suggestedBuilds)
    }
  }, components: {HomeBuildComponent, ReviewModal, SuggestionBuildComponent}
}
</script>

<style scoped lang="scss">
@media screen and (min-width: 576px) {
  .img-resize{
    max-height: 300px;
    max-width: 600px;
  }
}
@media screen and (max-width: 576px) {
  .img-resize{
    max-height: 100px;
    max-width: 300px;
  }
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

.section-build{
  outline: solid 2px purple;
  box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.171);
  overflow-y: scroll;
  height: 345px;
}

.home-btn{
  all: unset;
  padding-left: 8px;
  padding-right: 8px;
  padding-top: 4px;
  padding-bottom: 4px;
  outline: solid 2px purple;
  border-radius: 10px;
  background-color: white;
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
  background-color: rgb(212, 212, 212);
  color: black;
  cursor: pointer;
}

.info-top{
  background-color: rgba(128, 0, 128, 0.788);
  border-radius: 10px;
  padding: 5px;
  color: white;
  box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.432);
}

.info-top:hover{
  background-color: rgb(128, 0, 128);
  border-radius: 10px;
  padding: 5px;
  color: white;
}

.title-style{
  text-shadow: 3px 3px 3px black;
}
</style>
