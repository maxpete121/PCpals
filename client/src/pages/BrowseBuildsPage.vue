<template>
    <section class="container-fluid">
        <div class="row mt-3 justify-content-center">
            <div class="col-3">
                <SearchBuildComponent/>
            </div>
        </div>
        <div class="row text-center justify-content-center mt-3">
          <div class="col-2">
            <h3 class="title d-inline-block">Our Suggestions</h3>
          </div>
        </div>
        <div class="row justify-content-center text-center">
          <div class="col-lg-4 col-11" v-for="suggestedBuild in suggestedBuilds">
            <SuggestionBuildComponent :suggestedBuild="suggestedBuild"/>
          </div>
        </div>
        <div class="row mt-4 text-center justify-content-center">
          <div class="col-2">
            <h3 class="title d-inline-block ps-1 pe-1">All Builds</h3>
          </div>
        </div>
        <div class="row justify-content-center ps-4 pe-4 text-center pt-2 main-section">
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
import { suggestionService } from '../services/SuggestionService';
import SuggestionBuildComponent from '../components/SuggestionBuildComponent.vue';
  export default {
    setup() {
      onMounted(()=>{
        pcBuildService.getSharedBuilds()
        suggestionService.getSuggestions()
      })
      return {
        suggestedBuilds: computed(()=> AppState.suggestedBuilds),
        account: computed(() => AppState.account),
        allBuilds: computed(()=> AppState.recentBuilds)
      }
    }, components: {SearchBuildComponent, BrowseBuildComponent, SuggestionBuildComponent}
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

.title{
  border-bottom: solid 1px purple;
  padding-bottom: 5px;
}

  </style>