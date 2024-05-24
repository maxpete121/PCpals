<template>
    <div class="build-part d-flex justify-content-between align-items-center">
        <div>
            <img class="product-image" :src="pcPart.part.productImage" alt="Part Picture">
        </div>
        <div class="d-flex align-items-center mt-1">
            <h6>{{ pcPart.part.name }}</h6>
        </div>
        <div class="d-flex align-items-center">
            <div class="d-flex me-3 mt-1">
                <h6 class="me-2">Price:</h6>
                <h6>${{ pcPart.part.price }}</h6>
            </div>
            <button @click="deletePcPart()" class="btn btn-outline-danger"><i class="mdi mdi-delete"></i></button>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { PcPart } from '../models/PcPart.js';
import { pcPartService } from '../services/pcPartService.js';
import {pcBuildService} from '../services/PcBuildService.js'
export default {
    props: {pcPart: {type: PcPart, required: true}},
    setup(props){

        let activeBuild = computed(()=> AppState.activeBuildToEdit)
        async function deletePcPart(){
            if(props.pcPart.part.type == 'case'){
                let partData = {name: 'none', productImage: 'none', type: props.pcPart.part.type}
                await pcBuildService.updateBuildParts(activeBuild.value.id, partData)
                await pcPartService.deletePcPart(props.pcPart.id)
            }else{
                let partData = {name: 'none', productImage: activeBuild.value.casePicture, type: props.pcPart.part.type}
                await pcBuildService.updateBuildParts(activeBuild.value.id, partData)
                await pcPartService.deletePcPart(props.pcPart.id)
            }
        }
    return { 
        deletePcPart,
     }
    }
};
</script>


<style lang="scss" scoped>
.build-part{
    padding-top: 8px;
    padding-bottom: 8px;
    padding-left: 12px;
    padding-right: 12px;
    outline: solid 1px purple;
    color: black;
    border-radius: 5px;
    height: 70px;
    background-color: white;
    // box-shadow: 4px 4px 4px 1px rgba(0, 0, 0, 0.185);
}

.product-image{
    max-width: 100px;
    max-height: 60px;
}
</style>