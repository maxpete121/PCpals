<template>
    <div class="build-card d-flex align-items-center w-100">
        <div class="ms-1 d-flex flex-column align-items-center mt-1">
            <img class="cover-img" :src="casePic" alt="Case picture">
            <h3>{{ recentBuild.name }}</h3>
            <span class="d-flex text-success">
                <h4 class="fst-italic me-2">Price:</h4>
                <h4>${{ recentBuild.price }}</h4>
            </span>
        </div>
        <div class="d-flex flex-column justify-content-center">
            <div class="d-flex justify-content-center">
                    <h4>Speed</h4>
                    <div class="ms-2 speed-view">
                        <div class="progress progress-bg" role="progressbar" aria-label="Basic example"
                            aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                            <div class="progress-bar progress-bg-child" :style="progressWidth"></div>
                        </div>
                    </div>
                </div>
            <div class="specs text-center me-lg-4 ms-lg-3 ps-2 pe-2 pb-2 mt-1">
                <div class="sticky-top part-title">
                    <h5 class="fst-italic">Parts</h5>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Case</p>
                    <p class="fst-italic" v-if="recentBuild.pcCase && recentBuild.pcCase !== 'none'">{{ recentBuild.pcCase }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">CPU</p>
                    <p class="fst-italic" v-if="recentBuild.pcCpu && recentBuild.pcCpu !== 'none'">{{ recentBuild.pcCpu }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">GPU</p>
                    <p class="fst-italic" v-if="recentBuild.gpu && recentBuild.gpu !== 'none'">{{ recentBuild.gpu }}✅
                    </p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Ram</p>
                    <p class="fst-italic" v-if="recentBuild.ram && recentBuild.ram !== 'none'">{{ recentBuild.ram }}✅
                    </p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Motherboard</p>
                    <p class="fst-italic" v-if="recentBuild.motherBoard && recentBuild.motherBoard !== 'none'">{{ recentBuild.motherBoard }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Storage</p>
                    <p class="fst-italic" v-if="recentBuild.pcStorage && recentBuild.pcStorage !== 'none'">{{ recentBuild.pcStorage }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Power Supply</p>
                    <p class="fst-italic" v-if="recentBuild.powerSupply && recentBuild.powerSupply !== 'none'">{{ recentBuild.powerSupply }}✅</p>
                    <p v-else>None🚫</p>
                </div>
            </div>
            <div class="d-flex justify-content-center mt-3">
                <button class="btn-build me-3">Add to Cart</button>
                <button  class="btn-build me-3">Save Build</button>
                <button @click="getActiveReviews()" class="btn-build">Reviews</button>
                <div v-if="recentBuild.rating" class="d-flex ms-3">
                    <h5>{{ recentBuild.rating }}</h5>
                    <h5>/5⭐</h5>
                </div>
            </div>
        </div>
    </div>
    <ReviewModal id="reviewModal"/>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { PcBuild } from '../models/PcBuild';
import ReviewModal from './ReviewModal.vue';
import { reviewService } from '../services/ReviewService';
import { Modal } from 'bootstrap';
export default {
    props: { recentBuild: { type: PcBuild, required: true } },
    setup(props) {
        async function getActiveReviews(){
            await setActiveBuild()
            await reviewService.getActiveReviews(props.recentBuild.id)
            Modal.getOrCreateInstance("#reviewModal").show()
        }
        async function setActiveBuild(){
            await reviewService.setActiveBuild(props.recentBuild.id)
        }
        return {
            getActiveReviews,
            casePic: computed(() => {
                if (props.recentBuild.casePicture == 'none' || props.recentBuild.casePicture == null) {
                    return 'https://rusutikaa.github.io/docs/developer.apple.com/library/archive/referencelibrary/GettingStarted/DevelopiOSAppsSwift/Art/defaultphoto_2x.png'
                } else { return props.recentBuild.casePicture }
            }),
            progressWidth: computed(() => {
                let style = `width: ${props.recentBuild.powerScore}%`
                return style
            })
        }
    }, components: {ReviewModal}
};
</script>


<style lang="scss" scoped>
.build-card {
    outline: solid 1px purple;
    box-shadow: 3px 3px 3px 2px rgba(0, 0, 0, 0.219);
}

.speed-view {
    width: 150px;
    margin-top: 10px;
}

.progress-bg {
    background-color: gray;
}

.progress-bg-child {
    background-color: purple;
}

.specs {
    width: 380px;
    height: 170px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);

}

.part-title {
    background-color: rgba(255, 255, 255, 0.24);
    backdrop-filter: blur(5px);
    // padding-bottom: 3px;
}

.part-section {
    border-bottom: solid 1px purple;
    height: 28px;
    margin-top: 7px;
}

.cover-img {
    max-width: 140px;
    max-height: 100;
}

.btn-build {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px black;
    border-radius: 2px;
    color: white;
    background-color: purple;
}

.btn-build:hover {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px black;
    border-radius: 2px;
    color: white;
    background-color: rgb(146, 0, 146);
    cursor: pointer;
}

.btn-delete {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px red;
    background-color: red;
    color: white;
    border-radius: 2px;
}

.btn-delete:hover {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px red;
    border-radius: 2px;
    background-color: rgb(211, 0, 0);
    color: white;
    cursor: pointer;
}
</style>