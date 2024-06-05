<template>
    <section class="container-fluid">
        <div class="row mt-3 justify-content-center">
            <div class="col-3">
                <SearchBuildComponent/>
            </div>
        </div>
        <div class="row justify-content-center ps-4 pe-4 text-center pt-2 main-section">
          <h3>All Builds</h3>
            <div class="col-lg-4 col-12 build mt-3" v-for="allBuild in allBuilds">
              <BrowseBuildComponent :recentBuild="allBuild"/>
            </div>
        </div>
    </section>
  </template>
  
  <script>
  import { computed, onMounted } from 'vue';
  import { AppState } from '../AppState';
  import SearchBuildComponent from '../components/SearchBuildComponent.vue';
  import HomeBuildComponent from '../components/HomeBuildComponent.vue';
  import BrowseBuildComponent from '../components/BrowseBuildComponent.vue'
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
    }, components: {SearchBuildComponent, BrowseBuildComponent}
  }
  </script>
  
  <style scoped>
@media screen and (min-width: 576px) {
  .build{
  height: 300px;
}
}

@media screen and (max-width: 576px) {
  .build{
  height: 500px;
}
}

  </style>