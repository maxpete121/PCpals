<template>
    <div class="container-fluid">
        <div class="row mt-3 justify-content-center">
            <div class="col-lg-5 col-10">
                <div class="d-flex justify-content-evenly info-box mb-2">
                    <span class="pc-info mt-2">
                        <h4>{{ activeBuild.name }}</h4>
                    </span>
                    <span class="d-flex ms-4 pc-info mt-2">
                        <h4 class="me-2">Price:</h4>
                        <h4>${{ activeBuild.price }}</h4>
                    </span>
                    <span class="d-flex ms-4 pc-info mt-2">
                        <h4 class="me-2">Power Score:</h4>
                        <h4>{{ activeBuild.powerScore }}</h4>
                    </span>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic">Case</h4>
                    <div v-for="Case in Cases">
                        <PcPartComponent :pcPart="Case"/>
                    </div>
                    <div class="d-flex align-items-end" v-if="Cases.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic">CPU</h4>
                    <div v-for="CPU in CPUs">
                        <PcPartComponent :pcPart="CPU"/>
                    </div>
                    <div class="d-flex align-items-end" v-if="CPUs.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic">GPU</h4>
                    <div v-for="GPU in GPUs">
                        <PcPartComponent :pcPart="GPU"/>
                    </div>
                    <div class="d-flex align-items-end" v-if="GPUs.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic">MotherBoard</h4>
                    <div v-for="MotherBoard in Motherboards">
                        <PcPartComponent :pcPart="MotherBoard"/>
                    </div>
                    <div class="d-flex align-items-end" v-if="Motherboards.length == 0">
                        <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic">Ram</h4>
                    <div v-for="Ram in Rams">
                        <PcPartComponent :pcPart="Ram"/>
                    </div>
                    <div class="d-flex align-items-end" v-if="Rams.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic">Storage</h4>
                    <div v-for="Storage in Storages">
                        <PcPartComponent :pcPart="Storage"/>
                    </div>
                    <div class="d-flex align-items-end" v-if="Storages.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic">Power Supply</h4>
                    <div v-for="PowerSupply in PowerSupplys">
                        <PcPartComponent :pcPart="PowerSupply"/>
                    </div>
                    <div class="d-flex align-items-end" v-if="PowerSupplys.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
            </div>
            <div class="col-lg-5 col-12 d-flex flex-column align-items-center">
                <div class="sticky-top w-100">
                    <div class="w-100 d-flex justify-content-center">
                        <span class="box mt-2">
                            <button v-if="activeBuild.pcCase == null || activeBuild.pcCase == 'none'" @click="getStockParts('case')" class="type-button">Case</button>
                            <button v-if="activeBuild.pcCpu == null || activeBuild.pcCpu == 'none'" @click="getStockParts('cpu')" class="type-button">CPUs</button>
                            <button v-if="activeBuild.gpu == null || activeBuild.gpu == 'none'" @click="getStockParts('gpu')" class="type-button">GPUs</button>
                            <button v-if="activeBuild.motherBoard == null || activeBuild.motherBoard == 'none'" @click="getStockParts('motherB')" class="type-button">Motherboards</button>
                            <button v-if="activeBuild.ram == null || activeBuild.ram == 'none'" @click="getStockParts('ram')" class="type-button">RAM</button>
                            <button v-if="activeBuild.storage == null || activeBuild.storage == 'none'" @click="getStockParts('storage')" class="type-button">Storage</button>
                            <button v-if="activeBuild.powerSupply == null || activeBuild.powerSupply == 'none'" @click="getStockParts('powerS')" class="type-button-end">Power Supply</button>
                        </span>
                    </div>
                    <div class="d-flex" v-if="currentType == 'cpu'">
                        <button>Intel</button>
                        <h6 class="ms-3 me-3 mt-1">Or</h6>
                        <button>AMD</button>
                    </div>
                    <div class="w-100" v-for="stockPart in stockParts">
                     <StockPartComponent class="mt-3" :stockPart="stockPart"/>
                    </div>
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
        let pcParts = computed(()=> AppState.activeBuildParts)
        watch(account, getPcById)
        watch(activeBuild, getBuildParts)
        onMounted(()=>{
            if(account.value.id){
                pcPartService.allClear()
                getBuildParts()
            }
       })
        async function getPcById(){
            await pcBuildService.getPcById(route.params.buildId)
        }
        async function getStockParts(type){
            AppState.currentPartType = type
            await stockPartService.getStockParts(type)
        }
        async function getBuildParts(){
            await pcPartService.getBuildParts(activeBuild.value.id)
        }
        async function setCpuType(type){
            AppState.currentPartType = type
        }

    return { 
        activeBuild,
        getStockParts,
        stockParts: computed(()=> AppState.activeStockParts),
        pcParts: computed(()=> AppState.activeBuildParts),
        CPUs: computed(()=> AppState.cpu),
        GPUs: computed(()=> AppState.gpu),
        Motherboards: computed(()=> AppState.motherboard),
        Cases: computed(()=> AppState.case),
        Rams: computed(()=> AppState.ram),
        Storages: computed(()=> AppState.storage),
        PowerSupplys: computed(()=> AppState.powerSupply),
        currentType: computed(()=> AppState.currentPartType),
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
.pc-info{
    border-bottom: solid 1px purple;
}
.info-box{
    outline: solid 2px purple;
    padding-bottom: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.322);
    border-radius: 8px;
}
.part-holder{
    border-bottom: solid 2px purple;
    height: 100px;
    margin-top: 10px;
    padding-left: 8px;
    padding-right: 8px;
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