<template>
    <div class="review-card">
        <h5>{{ review.title }}</h5>
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
.review-card{
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.247);
}
</style>