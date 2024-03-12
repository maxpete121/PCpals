<template>
    <div class="container-fluid">
        <div class="row mt-3 justify-content-center">
            <div class="col-lg-5 col-10">
                <h4>{{ activeBuild.name }}</h4>
                <div></div>
                <div class="mt-3" v-for="pcPart in pcParts">
                <PcPartComponent :pcPart="pcPart"/>
                </div>
            </div>
            <div class="col-lg-5 col-12 d-flex flex-column align-items-center">
                <span class="box">
                    <button v-if="activeBuild.pcCase == null || activeBuild.pcCase == 'none'" @click="getStockParts('case')" class="type-button">Case</button>
                    <button v-if="activeBuild.pcCpu == null || activeBuild.pcCpu == 'none'" @click="getStockParts('cpu')" class="type-button">CPUs</button>
                    <button v-if="activeBuild.gpu == null || activeBuild.gpu == 'none'" @click="getStockParts('gpu')" class="type-button">GPUs</button>
                    <button v-if="activeBuild.motherBoard == null || activeBuild.motherBoard == 'none'" @click="getStockParts('motherB')" class="type-button">Motherboards</button>
                    <button v-if="activeBuild.ram == null || activeBuild.ram == 'none'" @click="getStockParts('ram')" class="type-button">RAM</button>
                    <button v-if="activeBuild.storage == null || activeBuild.storage == 'none'" @click="getStockParts('storage')" class="type-button">Storage</button>
                    <button v-if="activeBuild.powerSupply == null || activeBuild.powerSupply == 'none'" @click="getStockParts('powerSupply')" class="type-button-end">Power Supply</button>
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
import PcPartComponent from '../components/PcPartComponent.vue';
import { pcPartService } from '../services/pcPartService';
export default {
    setup(){
        let route = useRoute()
        let activeBuild = computed(()=> AppState.activeBuildToEdit)
        let account = computed(()=> AppState.account)
        watch(account, getPcById)
        watch(activeBuild, getBuildParts)
        onMounted(()=>{
            if(account.value.id){
                getBuildParts()
            }
       })
        async function getPcById(){
            await pcBuildService.getPcById(route.params.buildId)
        }
        async function getStockParts(type){
            await stockPartService.getStockParts(type)
        }
        async function getBuildParts(){
            await pcPartService.getBuildParts(activeBuild.value.id)
        }

    return { 
        activeBuild,
        getStockParts,
        stockParts: computed(()=> AppState.activeStockParts),
        pcParts: computed(()=> AppState.activeBuildParts)
     }
    }, components: {StockPartComponent, PcPartComponent}
};
</script>


<style lang="scss" scoped>
.box{
    outline: solid 2px purple;
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