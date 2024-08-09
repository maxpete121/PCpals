<template>
<div class="modal fade" id="reviewModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">Reviews for {{ activeBuild.name }}</h1>
        <button type="button" class="btn-close" @click="closeModal()" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div>
          <div class="text-center d-flex flex-column align-items-center">
            <button class="review-button mb-2" @click="backToDetails()"><i class="mdi mdi-arrow-left-bold"></i> Back to Details</button>
            <button v-if="account.id" style="display: block;" id="createButton" class="review-button" @click="showReviewCreate()">Leave a review!</button>
            <button style="display: none;" id="closeButton" class="review-button" @click="hideReviewCreate()">Close</button>
            <div style="display: none;" id="reviewCreateWrapper">
              <form @submit.prevent="createReview()" class="d-flex flex-column align-items-center mt-2">
                <div class="d-flex input-box pb-2">
                  <h6 class="me-2 mt-1">Title</h6>
                  <input required v-model="reviewData.title" type="text">
                </div>
                <div class="mt-2 d-flex flex-column input-box pb-2">
                  <h6 class="d-flex align-self-start justify-self-end">Description</h6>
                  <textarea class="" required v-model="reviewData.body" name="body" id="review-body" cols="30" rows="3"></textarea>
                </div>
                <div class="d-flex mt-2">
                  <select v-model="reviewData.stars" name="ratingSelect" id="ratingS">
                    <option value="1">⭐</option>
                    <option value="2">⭐⭐</option>
                    <option value="3">⭐⭐⭐</option>
                    <option value="4">⭐⭐⭐⭐</option>
                    <option value="5">⭐⭐⭐⭐⭐</option>
                  </select>
                  <button class="ms-2 btn btn-outline-dark">Post</button>
                </div>
              </form>
            </div>
          </div>
          <div class="review-holder">
            <div class="mt-3" v-for="activeReview in activeReviews">
              <ReviewComponent :review="activeReview"/>
            </div>
            <div class="text-center mt-3" v-if="activeReviews.length == 0">
              <h5>There are no reviews for this PC</h5>
            </div>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" @click="closeModal()">Close</button>
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
import {pcPartService} from '../services/pcPartService.js';
export default {
    setup(){
      let reviewData = ref()
      reviewData.value = {}
      let account = computed(()=> AppState.account)
      let activeBuild = computed(()=> AppState.activeBuildForReview)
      async function closeModal(){
        AppState.activeBuildReviews = []
        Modal.getOrCreateInstance("#reviewModal").hide()
      }

      async function createReview(){
        reviewData.value.buildId = AppState.activeBuildForReview.id
        reviewData.value.creatorId = account.value.id
        await reviewService.createReview(reviewData.value)
        reviewData.value = {}
      }

      async function backToDetails(){
        await pcPartService.getBuildParts(activeBuild.value.id)
        Modal.getOrCreateInstance("#reviewModal").hide()
        Modal.getOrCreateInstance("#BuildModal").show()
      }

      async function showReviewCreate(){
        document.getElementById("reviewCreateWrapper").style.display = 'block'
        document.getElementById("createButton").style.display = 'none'
        document.getElementById("closeButton").style.display = 'block'
      }
      async function hideReviewCreate(){
        document.getElementById("reviewCreateWrapper").style.display = 'none'
        document.getElementById("createButton").style.display = 'block'
        document.getElementById("closeButton").style.display = 'none'
      }
    return { 
      activeReviews: computed(()=> AppState.activeBuildReviews),
      account,
      activeBuild,
      createReview,
      closeModal,
      backToDetails,
      reviewData,
      showReviewCreate,
      hideReviewCreate,
     }
    }, components: {ReviewComponent}
};
</script>


<style lang="scss" scoped>
.checked{
  color: orange;
}
.input-box{
  border-bottom: solid 1px purple;
}

.review-button{
  all: unset;
  background-color: purple;
  border-radius: 3px;
  color: white;
  padding-top: 5px;
  padding-bottom: 5px;
  padding-right: 8px;
  padding-left: 8px;
}

.review-button:hover{
  all: unset;
  background-color: rgb(146, 0, 146);
  border-radius: 3px;
  color: white;
  padding-top: 5px;
  padding-bottom: 5px;
  padding-right: 8px;
  padding-left: 8px;
  cursor: pointer;
}
</style>