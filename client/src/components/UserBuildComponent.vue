<template>
    <div class="build-card d-flex flex-column align-items-center p-1 mt-3">
        <h3>{{ userBuild.name }}</h3>
        <div>
            <button class="me-2 btn-build">Add to Cart</button>
            <button @click="getPcById()" class="ms-2 btn-build me-2">Edit Build</button>
            <button v-if="userBuild.isPrivate == false" class="ms-2 btn-build me-2">Make Private</button>
            <button v-else class="ms-2 btn-build me-2">Share</button>
            <button class="btn-delete ms-2"><i class="mdi mdi-delete"></i></button>
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