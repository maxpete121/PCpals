<template>
    <div class="modal fade" id="BuildModal" tabindex="-1" aria-labelledby="BuildModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Reviews</h1>
            <button type="button" class="btn-close" @click="" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" @click="">Close</button>
          </div>
        </div>
      </div>
    </div>
    </template>
    
    
    <script>
    import { AppState } from '../AppState';
    import { computed, ref, onMounted } from 'vue';
    import { reviewService } from '../services/ReviewService';
    import { Modal } from 'bootstrap';
    import ReviewComponent from './ReviewComponent.vue';
    export default {
        setup(){

        return { 
          activeReviews: computed(()=> AppState.activeBuildReviews),
         }
        }, components: {ReviewComponent}
    };
    </script>
    
    
    <style lang="scss" scoped>
    </style>