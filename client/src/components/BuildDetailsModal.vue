<template>
    <div class="modal fade" id="BuildModal" tabindex="-1" aria-labelledby="BuildModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Details</h1>
            <button type="button" class="btn-close" @click="CloseModal()" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div class="d-flex justify-content-center">
                <h4 class="d-inline-block title-text">{{ activeBuild.name }}</h4>
            </div>
            <div class="d-flex justify-content-center mt-2">
                <h5 class="me-2">Build Price:</h5>
                <h5 class="text-success">${{ activeBuild.price }}</h5>
            </div>
            <div class="d-flex justify-content-center mt-2">
                <h5 class="me-2">Power Score:</h5>
                <h5>{{ activeBuild.powerScore }}/100</h5>
                <h4 class="ms-2 text-warning" title="Power scores are a general rating on a PCs capabilities"><i class="mdi mdi-information-box-outline"></i></h4>
                <p class="pt-1 ms-1 notification-text">Notification</p>
            </div>
            <div class="p-2 d-flex justify-content-center">
                <div class="warning-notification d-flex">
                    <h4 class="text-warning me-1"><i class="mdi mdi-information-outline"></i></h4>
                    <p class="notification-text">Power scores are a general rating of a PCs capabilities. The scores attributed to each available PC part are still being adjusted for better accuracy.</p>
                </div>
            </div>
              <div class="text-center mt-2">
                  <button class="review-button" @click="getReviews()">Reviews</button>
              </div>
              <div class="d-flex flex-column justify-content-center">
                <div v-for="buildPart in buildParts" class="build-part-section">
                    <div class="mt-4 d-flex flex-column align-items-center" v-if="buildPart.part.type == 'case'">
                        <h5 class="d-inline-block title-text">CASE:</h5>
                        <div class="part-showcase d-flex justify-content-evenly">
                            <img class="part-image" :src="buildPart.part.productImage" alt="cpu image">
                            <div class="text-center ms-lg-4 d-flex flex-column align-items-center">
                                <h6 class="mt-2 part-text">{{ buildPart.part.name }}</h6>
                                <div class="d-flex flex-lg-column justify-content-center mt-1 mt-lg-1 align-items-center">
                                    <div class="d-flex me-2 me-lg-0">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 d-flex flex-column align-items-center" v-if="buildPart.part.type == 'cpu'">
                        <h5 class="d-inline-block title-text">CPU:</h5>
                        <div class="part-showcase  d-flex justify-content-evenly">
                            <img class="part-image" :src="buildPart.part.productImage" alt="cpu image">
                            <div class="text-center ms-lg-4 d-flex flex-column align-items-center">
                                <h6 class="mt-2 part-text">{{ buildPart.part.name }}</h6>
                                <div class="d-flex flex-lg-column justify-content-center mt-1 mt-lg-1 align-items-center">
                                    <div class="d-flex me-2 me-lg-0">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                    <div class="d-flex text-center mt-lg-1">
                                        <h6 class="me-2 part-text">Speed:</h6>
                                        <h6 class="part-text">{{ buildPart.part.speed }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 d-flex flex-column align-items-center" v-if="buildPart.part.type == 'gpu'">
                        <h5 class="d-inline-block title-text">GPU:</h5>
                        <div class="part-showcase  d-flex justify-content-evenly">
                            <img class="part-image" :src="buildPart.part.productImage" alt="cpu image">
                            <div class="text-center ms-lg-4 d-flex flex-column align-items-center">
                                <h6 class="mt-2 part-text">{{ buildPart.part.name }}</h6>
                                <div class="d-flex flex-lg-column justify-content-center mt-1 mt-lg-1 align-items-center">
                                    <div class="d-flex me-2 me-lg-0">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                    <div class="d-flex text-center mt-lg-1">
                                        <h6 class="me-2 part-text">Gigs:</h6>
                                        <h6 class="part-text">{{ buildPart.part.gigs }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 d-flex flex-column align-items-center" v-if="buildPart.part.type == 'ram'">
                        <h5 class="d-inline-block title-text">RAM:</h5>
                        <div class="part-showcase  d-flex justify-content-evenly">
                            <img class="part-image" :src="buildPart.part.productImage" alt="cpu image">
                            <div class="text-center ms-lg-4 d-flex flex-column align-items-center">
                                <h6 class="mt-2 part-text">{{ buildPart.part.name }}</h6>
                                <div class="d-flex flex-lg-column justify-content-center mt-1 mt-lg-1 align-items-center mb-1">
                                    <div class="d-flex me-2 me-lg-0">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                    <div class="d-flex text-center mt-lg-1">
                                        <h6 class="me-2 part-text">Speed:</h6>
                                        <h6 class="part-text">{{ buildPart.part.speed }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 d-flex flex-column align-items-center" v-if="buildPart.part.type == 'motherB'">
                        <h5 class="d-inline-block title-text">MOTHERBOARD</h5>
                        <div class="part-showcase  d-flex justify-content-evenly">
                            <img class="part-image" :src="buildPart.part.productImage" alt="cpu image">
                            <div class="text-center ms-lg-4 d-flex flex-column align-items-center">
                                <h6 class="mt-2 part-text">{{ buildPart.part.name }}</h6>
                                <div class="d-flex flex-lg-column justify-content-center mt-1 mt-lg-1 align-items-center">
                                    <div class="d-flex me-2 me-lg-0">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 d-flex flex-column align-items-center" v-if="buildPart.part.type == 'storage'">
                        <h5 class="d-inline-block title-text">STORAGE:</h5>
                        <div class="part-showcase  d-flex justify-content-evenly">
                            <img class="part-image" :src="buildPart.part.productImage" alt="cpu image">
                            <div class="text-center ms-lg-4 d-flex flex-column align-items-center">
                                <h6 class="mt-2 part-text">{{ buildPart.part.name }}</h6>
                                <div class="d-flex flex-lg-column justify-content-center mt-1 mt-lg-1 align-items-center mb-1">
                                    <div class="d-flex me-2 me-lg-0">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                    <div class="d-flex text-center mt-lg-1">
                                        <h6 class="me-2 part-text">Capacity:</h6>
                                        <h6 class="part-text">{{ buildPart.part.gigs }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4 d-flex flex-column align-items-center" v-if="buildPart.part.type == 'powerS'">
                        <h5 class="d-inline-block title-text">POWER SUPPLY:</h5>
                        <div class="part-showcase  d-flex justify-content-evenly">
                            <img class="part-image" :src="buildPart.part.productImage" alt="cpu image">
                            <div class="text-center ms-lg-4 d-flex flex-column align-items-center">
                                <h6 class="part-text mt-1">{{ buildPart.part.name }}</h6>
                                <div class="d-flex flex-lg-column justify-content-center mt-1 mt-lg-1 align-items-center">
                                    <div class="d-flex me-2 me-lg-0">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                    <div class="d-flex text-center mt-lg-1">
                                        <h6 class="me-2 part-text">Wattage:</h6>
                                        <h6 class="part-text">{{ buildPart.part.watts }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
              </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" @click="CloseModal()">Close</button>
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
            let activeBuild = computed(()=> AppState.activeBuildForReview)

            async function CloseModal(){
                Modal.getOrCreateInstance("#BuildModal").hide()
                AppState.activeBuildParts = []
                AppState.activeBuildForReview = []
            }

            async function getReviews(){
                await reviewService.setActiveBuild(activeBuild.value.id)
            await reviewService.getActiveReviews(activeBuild.value.id)
            Modal.getOrCreateInstance("#BuildModal").hide()
            Modal.getOrCreateInstance("#reviewModal").show()
            }

        return { 
          CloseModal,  
          buildParts: computed(()=> AppState.activeBuildParts),
          activeBuild,
          getReviews,
         }
        }, components: {ReviewComponent}
    };
    </script>
    
    
    <style lang="scss" scoped>
    @media screen and (min-width: 576px){
        .part-showcase{
        outline: solid 2px purple;
        box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.315);
        max-height: 200px;
        width: 450px;
        padding: 5px;
        display: flex;
        justify-content: center;
    }
    .part-image{
        height: 20%;
        width: 20%;
    }
    }
    @media screen and (max-width: 576px){
        .part-showcase{
        outline: solid 2px purple;
        box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.315);
        max-height: 260px;
        width: 360px;
        padding: 5px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
    .part-image{
        height: 30%;
        width: 30%;
    }
    }

    .review-button{
        all: unset;
        outline: solid 2px black;
        border-radius: 6px;
        padding-top: 4px;
        padding-bottom: 4px;
        padding-left: 6px;
        padding-right: 6px;
        background-color: purple;
        color: white;
    }
    .review-button:hover{
        all: unset;
        outline: solid 2px black;
        border-radius: 6px;
        padding-top: 4px;
        padding-bottom: 4px;
        padding-left: 6px;
        padding-right: 6px;
        background-color: rgb(155, 0, 155);
        color: white;
        cursor: pointer;
    }

    .title-text{
        border-bottom: solid 1px purple;
        padding-left: 4px;
        padding-right: 4px;
    }

    .part-text{
        font-style: italic;
        font-weight: bold;
        margin: 0;
    }

    .warning-notification{
        background-color: rgba(255, 238, 1, 0.438);
        padding: 4px;
    }

    .notification-text{
        margin: 0;
        font-size: small;
    }
    </style>