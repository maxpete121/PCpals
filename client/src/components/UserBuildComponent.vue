<template>
    <div class="build-card d-flex align-items-center mt-3 p-1">
        <div class="text-center me-4 ms-4">
            <img class="cover-img" :src="userBuild.casePicture || 'https://rusutikaa.github.io/docs/developer.apple.com/library/archive/referencelibrary/GettingStarted/DevelopiOSAppsSwift/Art/defaultphoto_2x.png'" alt="">
            <h3>{{ userBuild.name }}</h3>
        </div>
        <div class="specs text-center me-3 ms-3">
            <h5>Parts</h5>
            <div class="d-flex justify-content-between part-section">
                <p class="me-2">CPU</p>
                <p class="fst-italic" v-if="userBuild.pcCpu && userBuild.pcCpu !== 'none'">{{ userBuild.pcCpu }}✅</p>
                <p v-else>None🚫</p>
            </div>
            <div class="d-flex justify-content-between part-section">
                <p class="me-2">GPU</p>
                <p class="fst-italic" v-if="userBuild.gpu && userBuild.gpu !== 'none'">{{ userBuild.gpu }}✅</p>
                <p v-else>None🚫</p>
            </div>
            <div class="d-flex justify-content-between part-section">
                <p class="me-2">Ram</p>
                <p class="fst-italic" v-if="userBuild.ram && userBuild.ram !== 'none'">{{ userBuild.ram }}✅</p>
                <p v-else>None🚫</p>
            </div>
            <div class="d-flex justify-content-between part-section">
                <p class="me-2">Motherboard</p>
                <p class="fst-italic" v-if="userBuild.motherBoard && userBuild.motherBoard !== 'none'">{{ userBuild.motherBoard }}✅</p>
                <p v-else>None🚫</p>
            </div>
        </div>
        <div class="d-flex flex-column align-items-center ms-4">
            <button class="btn-build">Add to Cart</button>
            <button v-if="userBuild.isPrivate == false" class="btn-build mt-2">Make Private</button>
            <button v-else class="btn-build mt-2">Share Build</button>
            <button @click="getPcById()" class="btn-build mt-2">Edit Build</button>
            <button class="btn-delete mt-2">Delete<i class="mdi mdi-delete"></i></button>
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
    return { 
        getPcById
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
    width: 360px;
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
    outline: solid 2px purple;
    border-radius: 2px;
}

.btn-build:hover{
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px purple;
    border-radius: 2px;
    cursor: pointer;
    background-color: rgb(236, 236, 236);
}

.btn-delete{
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px red;
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
    cursor: pointer;
    background-color: rgb(236, 236, 236);
}
</style>