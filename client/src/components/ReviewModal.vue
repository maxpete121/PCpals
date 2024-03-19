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
          <div class="text-center">
            <h3>Leave a review!</h3>
            <form >
              <div class="d-flex">
                <select v-model="reviewData.rating" name="rating" id="rating">
                  <option selected value="0">Rating</option>
                  <option value="1">⭐</option>
                  <option value="2">⭐⭐</option>
                  <option value="2">⭐⭐⭐</option>
                  <option value="2">⭐⭐⭐⭐</option>
                  <option value="2">⭐⭐⭐⭐⭐</option>
                </select>
                <button>Post</button>
              </div>
            </form>
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
      reviewData.value = {rating: 0}
      async function closeModal(){
        AppState.activeBuildReviews = []
        Modal.getOrCreateInstance("#reviewModal").hide()
      }
    return { 
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