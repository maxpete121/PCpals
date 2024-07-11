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
              <div>
                <div v-for="buildPart in buildParts" class="build-part-section">
                    <div class="mt-3 order-0" v-if="buildPart.part.type == 'case'">
                        <h5 class="d-inline-block title-text">CASE:</h5>
                        <div class="part-showcase">
                            <h6 class="me-4 part-text">{{ buildPart.part.name }}</h6>
                            <div class="d-flex mt-lg-0 mt-1">
                                <h6 class="part-text">Price:</h6>
                                <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                            </div>
                        </div>
                    </div>
                    <div class="mt-3 order-1" v-if="buildPart.part.type == 'cpu'">
                        <h5 class="d-inline-block title-text">CPU:</h5>
                        <div class="part-showcase">
                            <img class="part-image" :src="buildPart.part.productImage" alt="cpu image">
                            <div class="text-center">
                                <h6 class="me-lg-4 part-text">{{ buildPart.part.name }}</h6>
                                <div class="d-flex justify-content-center mt-1 mt-lg-0 align-items-center">
                                    <div class="d-flex">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                    <div class="d-flex ms-3">
                                        <h6 class="me-2 part-text">Speed:</h6>
                                        <h6 class="part-text">{{ buildPart.part.speed }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-3 order-2" v-if="buildPart.part.type == 'gpu'">
                        <h5 class="d-inline-block title-text">GPU:</h5>
                        <div class="part-showcase">
                            <img class="part-image" :src="buildPart.part.productImage" alt="gpu image">
                            <div>
                                <h6 class="me-lg-4 part-text">{{ buildPart.part.name }}</h6>
                                <div class="d-flex justify-content-center mt-1 mt-lg-0">
                                    <div class="d-flex mt-lg-0 mt-1">
                                        <h6 class="part-text">Price:</h6>
                                        <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                    </div>
                                    <div class="d-flex mt-1 ms-3">
                                        <h6 class="me-2 part-text">Gigs:</h6>
                                        <h6 class="part-text">{{ buildPart.part.gigs }}</h6>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-3 order-1" v-if="buildPart.part.type == 'ram'">
                        <h5 class="d-inline-block title-text">RAM:</h5>
                        <div class="part-showcase">
                            <h6 class="me-lg-4 part-text">{{ buildPart.part.name }}</h6>
                            <div class="d-flex mt-1 mt-lg-0">
                                <div class="d-flex mt-lg-0 mt-1">
                                    <h6 class="part-text">Price:</h6>
                                    <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                </div>
                                <div class="d-flex mt-1 ms-3">
                                    <h6 class="me-2 part-text">Speed:</h6>
                                    <h6 class="part-text">{{ buildPart.part.speed }}</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-3 order-2" v-if="buildPart.part.type == 'motherB'">
                        <h5 class="d-inline-block title-text">MOTHERBOARD:</h5>
                        <div class="part-showcase">
                            <h6 class="me-lg-4 part-text">{{ buildPart.part.name }}</h6>
                            <div class="d-flex mt-1 mt-lg-0">
                                <div class="d-flex mt-lg-0 mt-1">
                                    <h6 class="part-text">Price:</h6>
                                    <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-3 order-1" v-if="buildPart.part.type == 'storage'">
                        <h5 class="d-inline-block title-text">STORAGE:</h5>
                        <div class="part-showcase">
                            <h6 class="me-lg-4 part-text">{{ buildPart.part.name }}</h6>
                            <div class="d-flex mt-1 mt-lg-0">
                                <div class="d-flex mt-lg-0 mt-1">
                                    <h6 class="part-text">Price:</h6>
                                    <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                </div>
                                <div class="d-flex mt-1 ms-3">
                                    <h6 class="me-2 part-text">Space:</h6>
                                    <h6 class="part-text">{{ buildPart.part.gigs}}</h6>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mt-3 order-1" v-if="buildPart.part.type == 'powerS'">
                        <h5 class="d-inline-block title-text">POWER SUPPLY:</h5>
                        <div class="part-showcase">
                            <h6 class="me-lg-4 part-text">{{ buildPart.part.name }}</h6>
                            <div class="d-flex mt-1 mt-lg-0">
                                <div class="d-flex mt-lg-0 mt-1">
                                    <h6 class="part-text">Price:</h6>
                                    <h6 class="ms-2 text-success part-text">${{ buildPart.part.price }}</h6>
                                </div>
                                <div class="d-flex mt-1 ms-3">
                                    <h6 class="me-2 part-text">Wattage:</h6>
                                    <h6 class="part-text">{{ buildPart.part.watts}}</h6>
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
            async function CloseModal(){
                Modal.getOrCreateInstance("#BuildModal").hide()
                AppState.activeBuildParts = []
                AppState.activeBuildForReview = []
            }

            async function getReviews(){

            }

        return { 
          CloseModal,  
          buildParts: computed(()=> AppState.activeBuildParts),
          activeBuild: computed(()=> AppState.activeBuildForReview)
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
        max-width: 650px;
        padding: 5px;
        display: flex;
        justify-content: center;
    }
    }
    @media screen and (max-width: 576px){
        .part-showcase{
        outline: solid 2px purple;
        box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.315);
        max-height: 200px;
        max-width: 460px;
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

    </style>