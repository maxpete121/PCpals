<template>
    <div class="container-fluid">
        <div class="row mt-3">
            <div class="col-5">
                <h4>{{ activeBuild.name }}</h4>
            </div>
            <div class="col-6 d-flex flex-column align-items-center">
                <span class="box">
                    <button @click="getStockParts('cpu')" class="type-button">CPUs</button>
                    <button @click="getStockParts('gpu')" class="type-button">GPUs</button>
                    <button @click="getStockParts('motherboard')" class="type-button">Motherboards</button>
                    <button @click="getStockParts('ram')" class="type-button">RAM</button>
                    <button @click="getStockParts('storage')" class="type-button">Storage</button>
                    <button @click="getStockParts('powerSupply')" class="type-button-end">Power Supply</button>
                </span>
                <div class="w-100" v-for="stockPart in stockParts">
                 <StockPartComponent class="mt-3" :stockPart="stockPart"/>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, ref, onMounted, watch } from 'vue';
import { pcBuildService } from '../services/PcBuildService';
import { stockPartService } from '../services/StockPartService';
import StockPartComponent from '../components/StockPartComponent.vue';
export default {
    setup(){
        let route = useRoute()
        let activeBuild = computed(()=> AppState.activeBuildToEdit)
        let account = computed(()=> AppState.account)
        watch(account, getPcById)
        async function getPcById(){
            await pcBuildService.getPcById(route.params.buildId)
        }
        async function getStockParts(type){
            await stockPartService.getStockParts(type)
        }
    return { 
        activeBuild,
        getStockParts,
        stockParts: computed(()=> AppState.activeStockParts)
     }
    }, components: {StockPartComponent}
};
</script>


<style lang="scss" scoped>
.box{
    outline: solid 2px black;
    border-radius: 15px;
    overflow: hidden;
}
.type-button{
    all: unset;
    border-right: solid 1px black;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-left: 6px;
    padding-right: 6px;
}
.type-button{
    all: unset;
    border-right: solid 1px black;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-left: 6px;
    padding-right: 6px;
}
.type-button:hover{
    all: unset;
    border-right: solid 1px black;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-left: 6px;
    padding-right: 6px;
    cursor: pointer;
    background-color: rgb(231, 231, 231);
}
.type-button-end{
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-left: 6px;
    padding-right: 6px;
}
.type-button-end:hover{
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-left: 6px;
    padding-right: 6px;
    cursor: pointer;
    background-color: rgb(231, 231, 231);
}
</style>