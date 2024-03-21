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
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Reviews } from '../models/Reviews';
export default {
    props:{review: {type: Reviews, required: true}},
    setup(){
    return {  }
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