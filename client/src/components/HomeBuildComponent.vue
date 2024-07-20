<template>
    <div class="build-card d-lg-flex align-items-center pb-2 pt-2 mt-3">
        <div class="ms-1 d-flex flex-column align-items-center mt-1">
            <img class="cover-img" :src="casePic" alt="Case picture">
                <h4>{{ recentBuild.name }}</h4>
            <span class="d-flex text-success">
                <h4 class="fst-italic me-2">Price:</h4>
                <h4>${{ recentBuild.price }}</h4>
            </span>
        </div>
        <div class="d-flex flex-column justify-content-center">
            <div class="d-flex justify-content-center">
            <div class="d-flex justify-content-center mb-2 mt-1 pe-1">
                <button @click="createCartItem()" class="btn-build me-3">Add to Cart</button>
                <button @click="createSaveBuild()"  class="btn-build">Save Build</button>
                <button @click="OpenDetailsModal()" class="btn-build ms-3">Details</button>
            </div>
                </div>
            <div class="specs text-center me-lg-4 ms-lg-3 ps-2 pe-2 pb-2 mt-1">
                <div class="sticky-top part-title d-flex justify-content-center">
                    <h5 class="fst-italic title-child">PC Parts:</h5>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Case:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <h6 class="fst-italic part-text" v-if="recentBuild.pcCase && recentBuild.pcCase !== 'none'">{{ recentBuild.pcCase }}✅</h6>
                        <h6 v-else>None🚫</h6>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">CPU:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <h6 class="fst-italic part-text" v-if="recentBuild.pcCpu && recentBuild.pcCpu !== 'none'">{{ recentBuild.pcCpu }}✅</h6>
                        <h6 v-else>None🚫</h6>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">GPU:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <h6 class="fst-italic part-text" v-if="recentBuild.gpu && recentBuild.gpu !== 'none'">{{ recentBuild.gpu }}✅</h6>
                        <h6 v-else>None🚫</h6>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Ram:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center align-items-center">
                        <h6 class="fst-italic part-text" v-if="recentBuild.ram && recentBuild.ram !== 'none'">{{ recentBuild.ram }}✅</h6>
                        <h6 v-else>None🚫</h6>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Motherboard:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center align-items-center">
                        <h6 class="fst-italic part-text" v-if="recentBuild.motherBoard && recentBuild.motherBoard !== 'none'">{{ recentBuild.motherBoard }}✅</h6>
                        <h6 v-else>None🚫</h6>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Storage:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center align-items-center">
                        <h6 class="fst-italic part-text" v-if="recentBuild.pcStorage && recentBuild.pcStorage !== 'none'">{{ recentBuild.pcStorage }}✅</h6>
                        <h6 v-else>None🚫</h6>
                    </div>
                </div>
                <div class="">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Power Supply:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center ">
                        <h6 class="fst-italic part-text" v-if="recentBuild.powerSupply && recentBuild.powerSupply !== 'none'">{{ recentBuild.powerSupply }}✅</h6>
                        <h6 v-else>None🚫</h6>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center pt-3">
                    <div class="d-flex review-case">
                       <h6 class="rating-text">{{ recentBuild.rating }}</h6>
                       <h6 class="rating-text">/5⭐</h6>
                    </div>
                    <div class="d-flex speed-case align-items-center ms-2">
                        <h5 class="mt-1 text-light">Speed</h5>
                        <div class="ms-2 mb-2 speed-view">
                            <div class="progress progress-bg" role="progressbar" aria-label="Basic example"
                                aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                                <div class="progress-bar progress-bg-child" :style="progressWidth"></div>
                            </div>
                        </div>
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
import { cartItemService } from '../services/CartItemService';
import Pop from '../utils/Pop';
import { saveBuildService } from '../services/SaveBuildService';
import { AuthService } from '../services/AuthService';
import {pcPartService} from '../services/pcPartService.js'
export default {
    props: { recentBuild: { type: PcBuild, required: true } },
    setup(props) {
        let useAccount = computed(()=> AppState.account)
        async function getActiveReviews(){
            await setActiveBuild()
            await reviewService.getActiveReviews(props.recentBuild.id)
            Modal.getOrCreateInstance("#BuildModal").hide()
            Modal.getOrCreateInstance("#reviewModal").show()
        }
        async function OpenDetailsModal(){
            setActiveBuild()
            await pcPartService.getBuildParts(props.recentBuild.id)
            Modal.getOrCreateInstance("#BuildModal").show()
        }
        async function setActiveBuild(){
            await reviewService.setActiveBuild(props.recentBuild.id)
        }

        async function createCartItem(){
            if(useAccount.value.id){
                let itemData = {creatorId: useAccount.value.id, buildId: props.recentBuild.id}
                await cartItemService.createCartItem(itemData)
                Pop.success("Added to cart")
            }else if(window.confirm("You must create an account to add a build to your cart. Would you like to proceed?")){
                AuthService.loginWithPopup()
            }
        }

        async function createSaveBuild(){
            if(useAccount.value.id){
                let saveBuildData = {creatorId: useAccount.value.id, buildId: props.recentBuild.id}
                await saveBuildService.createSaveBuild(saveBuildData)
                Pop.success("Build Saved")
            }else if(window.confirm("You must create an account to save a build. Would you like to proceed?")){}
        }
        return {
            createSaveBuild,
            getActiveReviews,
            createCartItem,
            OpenDetailsModal,
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
@media screen and (min-width: 576px) {
    .specs {
    width: 360px;
    height: 165px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);
}
    .cover-img {
      max-width: 140px;
      max-height: 100;
   }
}

@media screen and (max-width: 576px) {
    .specs {
    width: 323px;
    height: 165px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);
    margin-left: 8px;
    margin-right: 8px;
}

 .cover-img {
      max-width: 100px;
      max-height: 60;
   }
}

.build-card {
    outline: solid 2px purple;
    box-shadow: 3px 3px 3px 2px rgba(0, 0, 0, 0.219);
    background-color: whitesmoke;
}

.speed-view {
    width: 150px;
    margin-top: 10px;
}

.progress-bg {
    background-color:rgb(88, 88, 88);
}

.progress-bg-child {
    background-color: #0cbc87;
}
.review-case{
    padding-left: 8px;
    padding-right: 3px;
    background-color: purple;
    color: white;
    padding-top: 5px;
    padding-bottom: 3px;
    border-radius: 5px;
    height: 31px;
    outline: solid 2px rgb(119, 0, 119);
}
.rating-text{
    height: 18px;
}
.part-type{
    height: 25px;  
}
.title-card{
    height: 27px;
    border-bottom: solid 1px purple;
}

.part-title {
    background-color: rgba(255, 255, 255, 0.24);
    backdrop-filter: blur(5px);
    height: 25px;
}
.title-child{
    border-bottom: solid 2px purple;
    height: 25px;
    width: 100px;
}

.speed-case{
    background-color: purple;
    outline: solid 2px rgb(119, 0, 119);
    height: 31px;
    border-radius: 5px;
    padding-left: 8px;
    padding-right: 8px;
}

.part-section {
    border: solid 1px purple;
    max-height: 70px;
    margin-top: 7px;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-left: 2px;
    padding-right: 2px;
    display: flex;
    align-items: center;
    text-align: center;
}
.part-text{
    margin: 0;
}

.btn-build {
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px rgb(119, 0, 119);
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
    outline: solid 2px rgb(119, 0, 119);
    border-radius: 2px;
    color: white;
    background-color: rgb(146, 0, 146);
    cursor: pointer;
}


</style>