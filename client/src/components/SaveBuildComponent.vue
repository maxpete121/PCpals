<template>
    <div class="build-card d-lg-flex align-items-center pb-1 mt-3">
        <div class="ms-1 d-flex flex-column align-items-center mt-1">
            <img class="cover-img" :src="casePic" alt="Case picture">
                <h3>{{ saveBuild.build.name }}</h3>
            <span class="d-flex text-success">
                <h4 class="fst-italic me-2">Price:</h4>
                <h4>${{ saveBuild.build.price }}</h4>
            </span>
        </div>
        <div class="d-flex flex-column justify-content-center">
            <div class="d-flex justify-content-center">
            <div class="d-flex justify-content-center mb-2 mt-1 pe-1">
                <button @click="createCartItem()" class="btn-build me-3">Add to Cart</button>
                <button @click="deleteSaveBuild()"  class="btn-build">Remove</button>
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
                        <p class="fst-italic" v-if="saveBuild.build.pcCase && saveBuild.build.pcCase !== 'none'">{{ saveBuild.build.pcCase }}✅</p>
                        <p v-else>None🚫</p>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">CPU:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <p class="fst-italic" v-if="saveBuild.build.pcCpu && saveBuild.build.pcCpu !== 'none'">{{ saveBuild.build.pcCpu }}✅</p>
                        <p v-else>None🚫</p>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">GPU:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <p class="fst-italic" v-if="saveBuild.build.gpu && saveBuild.build.gpu !== 'none'">{{ saveBuild.build.gpu }}✅</p>
                        <p v-else>None🚫</p>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Ram:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <p class="fst-italic" v-if="saveBuild.build.ram && saveBuild.build.ram !== 'none'">{{ saveBuild.build.ram }}✅</p>
                        <p v-else>None🚫</p>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Motherboard:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <p class="fst-italic" v-if="saveBuild.build.motherBoard && saveBuild.build.motherBoard !== 'none'">{{ saveBuild.build.motherBoard }}✅</p>
                        <p v-else>None🚫</p>
                    </div>
                </div>
                <div class="mb-2">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Storage:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <p class="fst-italic" v-if="saveBuild.build.pcStorage && saveBuild.build.pcStorage !== 'none'">{{ saveBuild.build.pcStorage }}✅</p>
                        <p v-else>None🚫</p>
                    </div>
                </div>
                <div class="">
                    <span class="d-flex justify-content-start part-type">
                        <h5 class="title-card">Power Supply:</h5>
                    </span>
                    <div class="part-section rounded-2 d-flex justify-content-center">
                        <p class="fst-italic" v-if="saveBuild.build.powerSupply && saveBuild.build.powerSupply !== 'none'">{{ saveBuild.build.powerSupply }}✅</p>
                        <p v-else>None🚫</p>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-center pt-3">
                    <div class="d-flex review-case">
                       <h6 class="rating-text">{{ saveBuild.build.rating }}</h6>
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
import { SaveBuild } from '../models/SaveBuild';
import {pcPartService} from '../services/pcPartService'
export default {
    props: { saveBuild: { type: SaveBuild, required: true } },
    setup(props) {
        let useAccount = computed(()=> AppState.account)
        async function OpenDetailsModal(){
            setActiveBuild()
            await pcPartService.getBuildParts(props.saveBuild.build.id)
            Modal.getOrCreateInstance("#BuildModal").show()
        }

        async function setActiveBuild(){
            await reviewService.setActiveBuild(props.saveBuild.buildId)
        }

        async function createCartItem(){
            let itemData = {creatorId: useAccount.value.id, buildId: props.saveBuild.buildId}
            await cartItemService.createCartItem(itemData)
            Pop.success("Added to cart")
        }

        async function deleteSaveBuild(){
            if(window.confirm("Do you want to remove this saved PC?")){
                let message = await saveBuildService.deleteSaveBuild(props.saveBuild.id)
                Pop.success(message)
            }
        }

        return {
            casePic: computed(() => {
                if (props.saveBuild.build.casePicture == 'none' || props.saveBuild.build.casePicture == null) {
                    return 'https://rusutikaa.github.io/docs/developer.apple.com/library/archive/referencelibrary/GettingStarted/DevelopiOSAppsSwift/Art/defaultphoto_2x.png'
                } else { return props.saveBuild.build.casePicture }
            }),
            progressWidth: computed(() => {
                let style = `width: ${props.saveBuild.build.powerScore}%`
                return style
            }),
            deleteSaveBuild,
            OpenDetailsModal,
            createCartItem,
        }
    }, components: {ReviewModal}
};
</script>


<style lang="scss" scoped>
.build-card {
    outline: solid 2px purple;
    box-shadow: 3px 3px 3px 2px rgba(0, 0, 0, 0.219);
    background-color: whitesmoke;
    border-radius: 7px;
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
.specs {
    width: 360px;
    height: 165px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);

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