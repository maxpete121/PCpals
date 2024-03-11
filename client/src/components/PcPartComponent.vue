<template>
    <div class="build-part d-flex justify-content-between">
        <div>
            <h4>{{ pcPart.part.name }}</h4>
        </div>
        <div>
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
            let partData = {name: 'none', productImage: '', type: props.pcPart.part.type}
            await pcBuildService.updateBuildParts(activeBuild.value.id, partData)
            await pcPartService.deletePcPart(props.pcPart.id)
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
    box-shadow: 4px 4px 4px 1px rgba(0, 0, 0, 0.185);
}
</style>