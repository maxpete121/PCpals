<template>
<div class="modal fade" id="reviewModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
        <button type="button" class="btn-close" @click="closeModal()" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div>
          <div class="text-center d-flex flex-column align-items-center">
            <h3>Leave a review!</h3>
            <form @submit.prevent="createReview()" class="d-flex flex-column align-items-center">
              <div>
                <h6>Title</h6>
                <input required v-model="reviewData.title" type="text">
              </div>
              <div class="mt-2">
                <h6>Description</h6>
                <textarea class="" required v-model="reviewData.body" name="body" id="review-body" cols="30" rows="3"></textarea>
              </div>
              <div class="d-flex mt-2">
                <select required v-model="reviewData.stars" name="rating" id="rating">
                  <option selected value="0">Rating</option>
                  <option value="1">⭐</option>
                  <option value="2">⭐⭐</option>
                  <option value="2">⭐⭐⭐</option>
                  <option value="2">⭐⭐⭐⭐</option>
                  <option value="2">⭐⭐⭐⭐⭐</option>
                </select>
                <button class="ms-2 btn btn-outline-dark">Post</button>
              </div>
            </form>
          </div>
          <div class="review-holder">
            <div v-for="activeReview in activeReviews">
              yes
            </div>
          </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" @click="closeModal()">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
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
        reviewData.value.creatorId = account.value.id
        reviewData.value.buildId = activeBuild.value.id
        await reviewService.createReview(reviewData.value)
        reviewData.value = {}
      }
    return { 
      activeReviews: computed(()=> AppState.activeBuildReviews),
      createReview,
      closeModal,
      reviewData,
     }
    }
};
</script>


<style lang="scss" scoped>
.checked{
  color: orange;
}
</style>