<template>
    <div class="build-card d-flex align-items-center mt-3 p-1 justify-content-between">
        <div class="text-center me-4 ms-4">
            <img class="cover-img" :src="casePic" alt="">
            <h3>{{ userBuild.name }}</h3>
        </div>
        <div>
            <div class="specs text-center me-4 ms-4 ps-2 pe-2 pb-2">
                <div class="sticky-top part-title">
                    <h5 class="fst-italic">Parts</h5>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Case</p>
                    <p class="fst-italic" v-if="userBuild.pcCase && userBuild.pcCase !== 'none'">{{ userBuild.pcCase }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">CPU</p>
                    <p class="fst-italic" v-if="userBuild.pcCpu && userBuild.pcCpu !== 'none'">{{ userBuild.pcCpu }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">GPU</p>
                    <p class="fst-italic" v-if="userBuild.gpu && userBuild.gpu !== 'none'">{{ userBuild.gpu }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Ram</p>
                    <p class="fst-italic" v-if="userBuild.ram && userBuild.ram !== 'none'">{{ userBuild.ram }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Motherboard</p>
                    <p class="fst-italic" v-if="userBuild.motherBoard && userBuild.motherBoard !== 'none'">{{ userBuild.motherBoard }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Storage</p>
                    <p class="fst-italic" v-if="userBuild.pcStorage && userBuild.pcStorage !== 'none'">{{ userBuild.pcStorage }}✅</p>
                    <p v-else>None🚫</p>
                </div>
                <div class="d-flex justify-content-between part-section rounded-2">
                    <p class="me-2">Power Supply</p>
                    <p class="fst-italic" v-if="userBuild.powerSupply && userBuild.powerSupply !== 'none'">{{ userBuild.powerSupply }}✅</p>
                    <p v-else>None🚫</p>
                </div>
            </div>
            <div class="d-flex justify-content-center mt-3">
                <button class="btn-build me-2">Add to Cart</button>
                <button v-if="userBuild.isPrivate == false" @click="updateShare('true')" class="btn-build me-2">Make Private</button>
                <button v-else @click="updateShare('false')" class="btn-build me-2">Share Build</button>
                <button @click="getPcById()" class="btn-build me-2">Edit Build</button>
                <button @click="deleteBuild()" class="btn-delete">Delete<i class="mdi mdi-delete"></i></button>
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
export default {
    props: {userBuild: {type: PcBuild, required: true}},
    setup(props){
        async function getPcById(){
            await pcBuildService.getPcById(props.userBuild.id)
            router.push({name: 'EditBuild', params: {buildId: props.userBuild.id}})
        }
        async function updateShare(){
                await pcBuildService.updateShare(props.userBuild.id)
        }
        async function deleteBuild(){
            if(window.confirm('Would you like to delete this build?'))
            await pcBuildService.deleteBuild(props.userBuild.id)
        }
    return { 
        deleteBuild,
        getPcById,
        updateShare,
        casePic: computed(()=>{
            if(props.userBuild.casePicture == 'none'){
                return 'https://rusutikaa.github.io/docs/developer.apple.com/library/archive/referencelibrary/GettingStarted/DevelopiOSAppsSwift/Art/defaultphoto_2x.png'
            }else{return props.userBuild.casePicture}
        })
     }
    }
};
</script>


<style lang="scss" scoped>
.cover-img{
    width: 130px;
    max-height: 100;
}

.specs{
    width: 380px;
    height: 170px;
    overflow-y: scroll;
    outline: solid 2px purple;
    border-radius: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.208);

}
.part-title{
    background-color: rgba(255, 255, 255, 0.24);
    backdrop-filter: blur(5px);
    // padding-bottom: 3px;
}

.part-section{
    border-bottom: solid 1px purple;
    height: 28px;
    margin-top: 7px;
}

.build-card{
    outline: solid 1px purple;
    box-shadow: 3px 3px 3px 2px rgba(0, 0, 0, 0.219);
}
.btn-build{
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

.btn-build:hover{
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

.btn-delete{
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

.btn-delete:hover{
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