<template>
    <div class="build-card mt-3 p-lg-1 p-2">
        <div class="d-lg-flex justify-content-between align-items-center">
            <div class="text-center me-4 ms-4">
                <img class="cover-img" :src="casePic" alt="">
                <h3 class="fst-italic">{{ userBuild.name }}</h3>
                <div class="d-flex justify-content-center">
                    <h4 class="me-2 fst-italic">Price:</h4>
                    <h4 class="text-success">${{ userBuild.price }}</h4>
                </div>
            </div>
            <div class="d-flex flex-column justify-content-center">
                <div class="d-flex justify-content-center align-items-baseline">
                    <h4>Speed</h4>
                    <div class="ms-2 speed-view">
                        <div class="progress progress-bg" role="progressbar" aria-label="Basic example"
                            aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                            <div class="progress-bar progress-bg-child" :style="progressWidth"></div>
                        </div>
                    </div>
                </div>
                <div class="specs text-center me-lg-4 ms-lg-4 ps-2 pe-2 pb-2 mt-1">
                    <div class="sticky-top part-title">
                        <h5 class="fst-italic">Parts</h5>
                    </div>
                    <div class="mb-2">
                        <span class="d-flex justify-content-start part-type">
                            <h5 class="title-card">Case:</h5>
                        </span>
                        <div class="part-section rounded-2 d-flex justify-content-center">
                            <p class="fst-italic part-text" v-if="userBuild.pcCase && userBuild.pcCase !== 'none'">{{ userBuild.pcCase }}✅</p>
                            <p class="part-text" v-else>None🚫</p>
                        </div>
                    </div>
                    <div class="mb-2">
                        <span class="d-flex justify-content-start part-type">
                            <h5 class="title-card">CPU:</h5>
                        </span>
                        <div class="part-section rounded-2 d-flex justify-content-center">
                            <p class="fst-italic part-text" v-if="userBuild.pcCpu && userBuild.pcCpu !== 'none'">{{ userBuild.pcCpu }}✅</p>
                            <p class="part-text" v-else>None🚫</p>
                        </div>
                    </div>
                    <div class="mb-2">
                        <span class="d-flex justify-content-start part-type">
                            <h5 class="title-card">GPU:</h5>
                        </span>
                        <div class="part-section rounded-2 d-flex justify-content-center">
                            <p class="fst-italic part-text" v-if="userBuild.gpu && userBuild.gpu !== 'none'">{{ userBuild.gpu }}✅</p>
                            <p class="part-text" v-else>None🚫</p>
                        </div>
                    </div>
                    <div class="mb-2">
                        <span class="d-flex justify-content-start part-type">
                            <h5 class="title-card">Ram:</h5>
                        </span>
                        <div class="part-section rounded-2 d-flex justify-content-center">
                            <p class="fst-italic part-text" v-if="userBuild.ram && userBuild.ram !== 'none'">{{ userBuild.ram }}✅</p>
                            <p class="part-text" v-else>None🚫</p>
                        </div>
                    </div>
                    <div class="mb-2">
                        <span class="d-flex justify-content-start part-type">
                            <h5 class="title-card">Motherboard:</h5>
                        </span>
                        <div class="part-section rounded-2 d-flex justify-content-center">
                            <p class="fst-italic part-text" v-if="userBuild.motherBoard && userBuild.motherBoard !== 'none'">{{ userBuild.motherBoard }}✅</p>
                            <p class="part-text" v-else>None🚫</p>
                        </div>
                    </div>
                    <div class="mb-2">
                        <span class="d-flex justify-content-start part-type">
                            <h5 class="title-card">Storage:</h5>
                        </span>
                        <div class="part-section rounded-2 d-flex justify-content-center">
                            <p class="fst-italic part-text" v-if="userBuild.pcStorage && userBuild.pcStorage !== 'none'">{{ userBuild.pcStorage }}✅</p>
                            <p class="part-text" v-else>None🚫</p>
                        </div>
                    </div>
                    <div class="">
                        <span class="d-flex justify-content-start part-type">
                            <h5 class="title-card">Power Supply:</h5>
                        </span>
                        <div class="part-section rounded-2 d-flex justify-content-center">
                            <p class="fst-italic part-text" v-if="userBuild.powerSupply && userBuild.powerSupply !== 'none'">{{ userBuild.powerSupply }}✅</p>
                            <p class="part-text" v-else>None🚫</p>
                        </div>
                    </div>
                </div>
                <div class="d-lg-flex justify-content-center mt-2 button-holder-lg">
                    <button @click="createCartItem()" class="btn-build me-2">Add to Cart</button>
                    <button v-if="userBuild.isPrivate == false" @click="updateShare('true')" class="btn-build me-2">Make Private</button>
                    <button v-else @click="updateShare('false')" class="btn-build me-2">Share Build</button>
                    <button @click="getPcById()" class="btn-build me-2">Edit Build</button>
                    <button @click="deleteBuild()" class="btn-delete">Delete<i class="mdi mdi-delete"></i></button>
                </div>
                <div class="align-items-center mt-2 button-holder-sm">
                    <div class="d-flex mt-2">
                        <button class="btn-build me-2">Add to Cart</button>
                        <button v-if="userBuild.isPrivate == false" @click="updateShare('true')" class="btn-build me-2">Make Private</button>
                        <button v-else @click="updateShare('false')" class="btn-build me-2">Share Build</button>
                        <button @click="getPcById()" class="btn-build">Edit Build</button>
                    </div>
                    <div class="d-flex mt-3">
                        <button @click="deleteBuild()" class="btn-delete">Delete<i class="mdi mdi-delete"></i></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { PcBuild } from '../models/PcBuild';
import { pcBuildService } from '../services/PcBuildService';
import { router } from '../router';
import Pop from '../utils/Pop';
import {cartItemService} from '../services/CartItemService'
import {AuthService} from '../services/AuthService'
export default {
    props: { userBuild: { type: PcBuild, required: true } },
    setup(props) {
        let useAccount = computed(()=> AppState.account)
        async function getPcById() {
            if(props.userBuild.isPrivate == false){
                if(window.confirm("Editing a public build will make it private. Would you like to continue?")){
                    await updateShare()
                    await pcBuildService.getPcById(props.userBuild.id)
                    router.push({ name: 'EditBuild', params: { buildId: props.userBuild.id } })
                }
            }else{
                await pcBuildService.getPcById(props.userBuild.id)
                router.push({ name: 'EditBuild', params: { buildId: props.userBuild.id } })
            }
        }
        async function updateShare() {
            await pcBuildService.updateShare(props.userBuild.id)
        }
        async function deleteBuild() {
            if (window.confirm('Would you like to delete this build?'))
                await pcBuildService.deleteBuild(props.userBuild.id)
        }
        async function createCartItem(){
            if(useAccount.value.id){
                let itemData = {creatorId: useAccount.value.id, buildId: props.userBuild.id}
                await cartItemService.createCartItem(itemData)
                Pop.success("Added to cart")
            }else if(window.confirm("You must create an account to add a build to your cart. Would you like to proceed?")){
                AuthService.loginWithPopup()
            }
        }
        return {
            deleteBuild,
            getPcById,
            updateShare,
            createCartItem,
            casePic: computed(() => {
                if (props.userBuild.casePicture == 'none' || props.userBuild.casePicture == null) {
                    return 'https://rusutikaa.github.io/docs/developer.apple.com/library/archive/referencelibrary/GettingStarted/DevelopiOSAppsSwift/Art/defaultphoto_2x.png'
                } else { return props.userBuild.casePicture }
            }),
            progressWidth: computed(() => {
                let style = `width: ${props.userBuild.powerScore}%`
                return style
            })
        }
    }
};
</script>


<style lang="scss" scoped>
@media screen and (min-width: 576px) {
    .specs {
    width: 385px;
    height: 170px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);
}

   .button-holder-lg{
    display: block;
   }

   .button-holder-sm{
    visibility: hidden;
    display: none;
   }
}

@media screen and (max-width: 576px) {
    .specs {
    width: 325px;
    height: 170px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);
}

   .button-holder-lg{
    visibility: hidden;
    display: none;
   }

   .button-holder-sm{
    display: flex;
    flex-direction: column;
   }
}

.cover-img {
    width: 130px;
    max-height: 100;
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

.part-title {
    background-color: rgba(255, 255, 255, 0.24);
    backdrop-filter: blur(5px);
    // padding-bottom: 3px;
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

.part-type{
    height: 25px;  
}
.title-card{
    height: 27px;
    border-bottom: solid 1px purple;
}
.build-card {
    outline: solid 1px purple;
    box-shadow: 3px 3px 3px 2px rgba(0, 0, 0, 0.219);
    border-radius: 10px;
    background-color: white;
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