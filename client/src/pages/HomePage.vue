<template>
<section class="container-fluid">
  <div class="row justify-content-center">
    <div class="col-3 text-center main ps-2 pe-2">
      <h3>Find a PC</h3>
      <p>Browse our selection of high end gaming PCs, or check out other users builds.</p>
      <button class="home-btn">Browse</button>
    </div>
    <div class="col-3 text-center main ms-4 me-4">
      <h3>Build your own PC</h3>
      <p>Make an account or sign in to create a PC build and share it with others!</p>
      <button class="home-btn ms-4 me-4">Pc Builder</button>
    </div>
    <div class="col-3 text-center main">
      <h3>Schedule a clean</h3>
      <p>Submit a ticket to our team to get your PC cleaned today!</p>
      <button class="home-btn">Get a clen</button>
    </div>
  </div>
  <div class="row justify-content-center">
    <div class="col-lg-5 col-11 section-build me-lg-4">
      <h4>Our Suggestions</h4>
      <div class=""></div>
    </div>
    <div class="col-lg-5 col-11 d-flex flex-column align-items-center section-build pt-1 pb-3">
      <h4>Recent Builds</h4>
      <div class="d-flex justify-content-center mb-3" v-for="recentBuild in recentBuilds">
        <HomeBuildComponent :recentBuild="recentBuild"/>
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
export default {
  setup() {
    onMounted(()=>{
      getSharedBuilds()
    })
    async function getSharedBuilds(){
      await pcBuildService.getSharedBuilds()
    }
    return {
      recentBuilds: computed(()=> AppState.recentBuilds)
    }
  }, components: {HomeBuildComponent, ReviewModal}
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
  background-image: image-set('../assets/img/test1.png');
  background-position: center;
  background-size: cover;
  height: 288px;
  padding-top: 70px;
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
  border-radius: 15px;
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
  cursor: pointer;
}
</style>
