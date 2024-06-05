<template>
    <section class="container-fluid">
        <div class="row mt-3 justify-content-center">
            <div class="col-3">
                <SearchBuildComponent/>
            </div>
        </div>
        <div class="row justify-content-center ps-4 pe-4 text-center pt-2">
          <h3>All Builds</h3>
          <div class="col-lg-4 col-11 mt-3 build" v-for="allBuild in allBuilds">
            <HomeBuildComponent :recentBuild="allBuild"/>
          </div>
        </div>
    </section>
  </template>
  
  <script>
  import { computed, onMounted } from 'vue';
  import { AppState } from '../AppState';
  import SearchBuildComponent from '../components/SearchBuildComponent.vue';
  import HomeBuildComponent from '../components/HomeBuildComponent.vue';
import { pcBuildService } from '../services/PcBuildService';
  export default {
    setup() {
      onMounted(()=>{
        pcBuildService.getSharedBuilds()
      })
      return {
        account: computed(() => AppState.account),
        allBuilds: computed(()=> AppState.recentBuilds)
      }
    }, components: {SearchBuildComponent, HomeBuildComponent}
  }
  </script>
  
  <style scoped>
.build{
  height: 400px;
}

@media screen and (min-width: 576px) {
    .specs {
    width: 360px;
    height: 165px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);
}
    .cover-img {
      max-width: 140px;
      max-height: 100;
   }
}

@media screen and (max-width: 576px) {
    .specs {
    width: 320px;
    height: 165px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);
    margin-left: 10px;
    margin-right: 10px;
}

 .cover-img {
      max-width: 100px;
      max-height: 60;
   }
}
  </style>