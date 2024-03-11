<template>
    <div class="part-card d-flex align-items-center justify-content-between w-100">
        <div class="d-flex align-items-center">
            <img class="part-image" :src="stockPart.productImage" alt="Part image">
            <p class="ms-3 text-size">{{ stockPart.name }}</p>
        </div>
        <div class="d-flex align-items-center">
            <h6 class="me-2 mt-2">Speed</h6>
            <div class="me-2 speed-view">
                <div class="progress progress-bg" role="progressbar" aria-label="Basic example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                    <div class="progress-bar progress-bg-child" :style="progressWidth"></div>
                </div>
            </div>
            <div class="options-card me-3 d-flex align-items-center">
                <button class="option-button">Details</button>
                <button @click="addPcPart()" class="option-button-two">Add</button>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { StockPart } from '../models/StockPart';
import { pcBuildService } from '../services/PcBuildService';
import { pcPartService } from '../services/pcPartService';
export default {
    props: { stockPart: { type: StockPart, required: true } },
    setup(props) {
        let account = computed(()=> AppState.account)
        let activeBuild = computed(()=> AppState.activeBuildToEdit)
        async function addPcPart(){
            let pcPartData = {buildId: activeBuild.value.id, creatorId: account.value.id, partId: props.stockPart.id}
            await pcPartService.addPcPart(pcPartData)

        }
        return {
            addPcPart,
            progressWidth: computed(()=>{
                let style = `width: ${props.stockPart.powerScore}%`
                return style
            })
        }
    }
};
</script>


<style lang="scss" scoped>
@media screen and (max-width: 576px){
    .text-size{
        font-size: x-small;
    }
}
.part-card {
    outline: solid 1px purple;
    box-shadow: 5px 5px 5px 0px rgba(0, 0, 0, 0.152);
}

.part-card:hover {
    outline: solid 1px purple;
    cursor: pointer;
    transform: scale(1.02);
}

.part-image {
    max-height: 70px;
    max-width: 170px;
    border-radius: 10px;
}

.speed-view{
    width: 70px;
}

.progress-bg{
    background-color: gray;
}

.progress-bg-child{
    background-color: purple;
}

.options-card {
    outline: solid 1px white;
    border-radius: 20px;
    overflow: hidden;
    padding: 1px;
}

.option-button {
    all: unset;
    border-right: solid 2px white;
    color: white;
    background-color: purple;
    padding-top: 4px;
    padding-bottom: 4px;
    padding-left: 9px;
    padding-right: 9px;
}

.option-button:hover {
    all: unset;
    border-right: solid 2px white;
    color: white;
    background-color: rgb(143, 0, 143);
    padding-top: 4px;
    padding-bottom: 4px;
    padding-left: 9px;
    padding-right: 9px;
}

.option-button-two {
    all: unset;
    color: white;
    background-color: purple;
    padding-top: 4px;
    padding-bottom: 4px;
    padding-left: 9px;
    padding-right: 9px;
}

.option-button-two:hover {
    all: unset;
    color: white;
    background-color: rgb(143, 0, 143);
    padding-top: 4px;
    padding-bottom: 4px;
    padding-left: 9px;
    padding-right: 9px;
}

.progress-blank {
    background-color: gray;
    color: gray;
    border-radius: 4px;
    padding-right: 1px;
}

.progress-filled {
    background-color: purple;
    color: purple;
    border-radius: 4px;
    padding-right: 1px;
}
</style>