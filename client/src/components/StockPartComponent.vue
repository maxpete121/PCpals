<template>
    <div class="part-card d-flex align-items-center justify-content-between w-100 pt-1 pb-1 ps-2 pe-2">
        <div class="d-flex flex-column flex-lg-row text-center align-items-center justify-content-lg-start justify-content-between w-50">
            <img class="part-image ms-lg-1" :src="stockPart.productImage" alt="Part image">
            <div class="d-flex mt-lg-0 mt-1 ms-lg-3">
                <h6 v-if="stockPart.type == 'case'" class="me-2">Quality</h6>
                <h6 v-else class="me-2">Speed</h6>
                <div class="me-2 speed-view mt-1">
                    <div class="progress progress-bg" role="progressbar" aria-label="Basic example" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                        <div class="progress-bar progress-bg-child" :style="progressWidth"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="d-flex flex-column text-center flex-lg-row justify-content-lg-end align-items-center w-50">
            <h5 class="text-size">{{ stockPart.name }}</h5>
            <div class="d-flex ms-lg-3 price-area justify-content-center me-lg-3">
                    <h6 class="me-2">Price:</h6>
                    <h6>${{ stockPart.price }}</h6>
            </div>
            <div class="">
                <div class="options-card d-flex align-items-center">
                    <button class="option-button">Info</button>
                    <button @click="addPcPart()" class="option-button-two">Add</button>
                </div>
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
            await pcBuildService.updateBuildParts(activeBuild.value.id, props.stockPart)
            AppState.activeStockParts = []
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
        font-size: small;
    }
    .part-image {
    max-height: 70px;
    max-width: 100px;
}
}

@media screen and (min-width: 576px){
    .text-size{
        font-size: small;
    }
    .part-image {
    max-height: 70px;
    max-width: 170px;
}
}
.part-card {
    outline: solid 1px purple;
    box-shadow: 5px 5px 5px 0px rgba(0, 0, 0, 0.152);
}

.price-area{
    height: 25px;
}
.part-card:hover {
    outline: solid 1px purple;
    cursor: pointer;
    transform: scale(1.02);
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
    width: 96px;
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