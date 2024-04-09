<template>
    <section class="container-fluid">
        <div class="row mt-3 justify-content-center">
            <div class="col-3">
                <SearchBuildComponent/>
            </div>
        </div>
    </section>
  </template>
  
  <script>
  import { computed } from 'vue';
  import { AppState } from '../AppState';
  import SearchBuildComponent from '../components/SearchBuildComponent.vue';
  export default {
    setup() {
      return {
        account: computed(() => AppState.account)
      }
    }, components: {SearchBuildComponent}
  }
  </script>
  
  <style scoped>

  </style>