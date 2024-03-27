<template>
    <div class="review-card p-1 d-flex flex-column align-items-center">
        <span class="d-flex rating">
            <p>{{ review.stars }}</p>
            <p>/5⭐</p>
        </span>
        <h5 class="title">{{ review.title }}</h5>
        <div class="w-100 ms-3">
            <h6>Description</h6>
            <p>{{ review.body }}</p>
        </div>
        <div v-if="account.id == review.creatorId">
            <button @click="deleteReview()" class="btn btn-outline-danger"><i class="mdi mdi-delete"></i></button>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Reviews } from '../models/Reviews';
import { reviewService } from '../services/ReviewService';
import Pop from '../utils/Pop';
export default {
    props:{review: {type: Reviews, required: true}},
    setup(props){
        async function deleteReview(){
            if(window.confirm('Are you sure you want to delete your review?')){
                let message = await reviewService.deleteReview(props.review.id)
                Pop.success(message)
            }
        }
    return { 
        account: computed(()=> AppState.account),
        deleteReview,
     }
    }
};
</script>


<style lang="scss" scoped>
.rating{
    height: 18px;
}
.title{
    height: 20px;
}
.review-card{
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.247);
    border-top: solid 1px purple;
    border-left: solid 1px purple;
}
</style>