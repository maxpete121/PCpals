<template>
    <section class="container-fluid">
        <div class="row mt-3 justify-content-center">
            <div class="col-3">
                <SearchBuildComponent/>
            </div>
        </div>
        <div class="row justify-content-center mt-4 mb-2">
          <div class="col-2 d-flex justify-content-center">
            <h3 class="title ps-1 pe-1">Our Suggestions</h3>
          </div>
        </div>
        <div class="row justify-content-center text-center">
          <div class="col-lg-5 col-11" v-for="suggestedBuild in suggestedBuilds">
            <SuggestionBuildComponent :suggestedBuild="suggestedBuild"/>
          </div>
        </div>
        <div class="row mt-4 d-flex justify-content-center">
          <div class="col-2 d-flex justify-content-center">
            <h3 class="title ps-1 pe-1">All Builds</h3>
          </div>
        </div>
        <div class="row justify-content-center ps-4 pe-4 text-center pt-2 main-section">
            <div class="col-lg-5 col-12 build mt-3" v-for="allBuild in allBuilds">
              <BrowseBuildComponent :recentBuild="allBuild"/>
            </div>
        </div>
        <BuildDetailsModal id="BuildModal"/>
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
import BuildDetailsModal from '../components/BuildDetailsModal.vue'
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
    }, components: {SearchBuildComponent, BrowseBuildComponent, SuggestionBuildComponent, BuildDetailsModal}
  }
  </script>
  
  <style scoped>
@media screen and (min-width: 576px) {
  .build{
  height: 300px;
}

.title{
  border-bottom: solid 1px purple;
  padding-bottom: 5px;
}
}

@media screen and (max-width: 576px) {
  .build{
  height: 500px;
}

.title{
  border-bottom: solid 1px purple;
  padding-bottom: 5px;
}
}


  </style>