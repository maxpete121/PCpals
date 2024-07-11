<template>
    <div class="container-fluid">
        <div class="row mt-3 justify-content-center">
            <div class="col-lg-5 col-12 pb-2 bg-dark pt-3 part-view order-lg-0 order-1">
                <div class="mb-2 p-2 d-lg-flex justify-content-center">
                    <div class="info-box bg-light p-2">
                        <div class="pc-info d-flex justify-content-between">
                            <h5 class="ms-3 me-2">Build name:</h5>
                            <h5 class="me-2" >{{ activeBuild.name }}</h5>
                        </div>
                        <div class="pc-info mt-2 d-flex justify-content-between mt-1">
                            <h5 class="ms-3 me-2">Price:</h5>
                            <h5 class="me-2 text-success" >${{ activeBuild.price }}</h5>
                        </div>
                        <div class="pc-info mt-2 d-flex justify-content-between mt-1">
                            <h5 class="ms-3 me-2">Power Score:</h5>
                            <h5 class="me-2" >{{ activeBuild.powerScore }}%</h5>
                        </div>
                        <div class="pc-info mt-2 d-flex justify-content-between mt-1">
                            <h5 class="ms-3 me-2">Wattage:</h5>
                            <h5 v-if="activeBuild.watts < activeBuild.maxWattage" class="me-2" >{{ activeBuild.watts }} / {{ activeBuild.maxWattage }}</h5>
                            <h5 v-else-if="activeBuild.watts >= activeBuild.maxWattage" class="me-2 text-danger" >{{ activeBuild.watts }} / {{ activeBuild.maxWattage }}</h5>
                        </div>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic text-light">Case</h4>
                    <div v-for="Case in Cases">
                        <PcPartComponent :pcPart="Case"/>
                    </div>
                    <div class="d-flex align-items-end pt-4 pt-lg-0" v-if="Cases.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic text-light">CPU</h4>
                    <div v-for="CPU in CPUs">
                        <PcPartComponent :pcPart="CPU"/>
                    </div>
                    <div class="d-flex align-items-end pt-4 pt-lg-0" v-if="CPUs.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic text-light">GPU</h4>
                    <div v-for="GPU in GPUs">
                        <PcPartComponent :pcPart="GPU"/>
                    </div>
                    <div class="d-flex align-items-end pt-4 pt-lg-0" v-if="GPUs.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic text-light">MotherBoard</h4>
                    <div v-for="MotherBoard in Motherboards">
                        <PcPartComponent :pcPart="MotherBoard"/>
                    </div>
                    <div class="d-flex align-items-end pt-4 pt-lg-0" v-if="Motherboards.length == 0">
                        <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic text-light">Ram</h4>
                    <div v-for="Ram in Rams">
                        <PcPartComponent :pcPart="Ram"/>
                    </div>
                    <div class="d-flex align-items-end pt-4 pt-lg-0" v-if="Rams.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic text-light">Storage</h4>
                    <div v-for="Storage in Storages">
                        <PcPartComponent :pcPart="Storage"/>
                    </div>
                    <div class="d-flex align-items-end pt-4 pt-lg-0" v-if="Storages.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
                <div class="part-holder">
                    <h4 class="fst-italic text-light">Power Supply</h4>
                    <div v-for="PowerSupply in PowerSupplys">
                        <PcPartComponent :pcPart="PowerSupply"/>
                    </div>
                    <div class="d-flex align-items-end pt-4 pt-lg-0" v-if="PowerSupplys.length == 0">
                    <h4 class="mt-4 text-danger">No Part selected...</h4>
                    </div>
                </div>
            </div>
            <div class="col-lg-5 col-12 d-flex flex-column align-items-center order-lg-1 order-0 ps-3 pe-3 ms-lg-4 mb-3 mb-lg-0">
                <div class="sticky-top w-100">
                    <div class="text-center">
                        <h4 class="title-font d-inline-block ps-2 pe-2">Add Parts</h4>
                    </div>
                    <div class="w-100 d-flex justify-content-center">
                        <span class="box select-large mt-2">
                            <button v-if="activeBuild.pcCase == null || activeBuild.pcCase == 'none'" @click="getStockParts('case')" class="type-button">Case</button>
                            <button v-if="activeBuild.pcCpu == null || activeBuild.pcCpu == 'none'" @click="getStockParts('cpu')" class="type-button">CPUs</button>
                            <button v-if="activeBuild.gpu == null || activeBuild.gpu == 'none'" @click="getStockParts('gpu')" class="type-button">GPUs</button>
                            <button v-if="activeBuild.motherBoard == null || activeBuild.motherBoard == 'none'" @click="getStockParts('motherB')" class="type-button">Motherboards</button>
                            <button v-if="activeBuild.ram == null || activeBuild.ram == 'none'" @click="getStockParts('ram')" class="type-button">RAM</button>
                            <button v-if="activeBuild.storage == null || activeBuild.storage == 'none'" @click="getStockParts('storage')" class="type-button">Storage</button>
                            <button v-if="activeBuild.powerSupply == null || activeBuild.powerSupply == 'none'" @click="getStockParts('powerS')" class="type-button-end">Power Supply</button>
                        </span>
                        <div class="d-flex flex-column align-items-center">
                            <span class="box select-small mt-2">
                                <button v-if="activeBuild.pcCase == null || activeBuild.pcCase == 'none'" @click="getStockParts('case')" class="type-button">Case</button>
                                <button v-if="activeBuild.pcCpu == null || activeBuild.pcCpu == 'none'" @click="getStockParts('cpu')" class="type-button">CPUs</button>
                                <button v-if="activeBuild.gpu == null || activeBuild.gpu == 'none'" @click="getStockParts('gpu')" class="type-button">GPUs</button>
                                <button v-if="activeBuild.motherBoard == null || activeBuild.motherBoard == 'none'" @click="getStockParts('motherB')" class="type-button">Motherboards</button>
                            </span>
                            <span class="box select-small mt-3">
                                <button v-if="activeBuild.ram == null || activeBuild.ram == 'none'" @click="getStockParts('ram')" class="type-button">RAM</button>
                                <button v-if="activeBuild.storage == null || activeBuild.storage == 'none'" @click="getStockParts('storage')" class="type-button">Storage</button>
                                <button v-if="activeBuild.powerSupply == null || activeBuild.powerSupply == 'none'" @click="getStockParts('powerS')" class="type-button-end">Power Supply</button>
                            </span>
                        </div>
                    </div>
                    <div class="mt-3 text-center" v-if="currentType == 'cpu' && Motherboards.length == 0 && CPUs.length == 0">
                        <h4 class="title-font d-inline-block">Company</h4>
                        <div class="d-flex justify-content-center">
                            <button class="cpu-select-button me-2" @click="setCpuType('Intel')">Intel</button>
                            <button class="cpu-select-button" @click="setCpuType('AMD')">AMD</button>
                        </div>
                    </div>
                    <div class="text-center mt-3" v-if="currentType == 'motherB' && CPUs.length == 0 && Motherboards.length == 0">
                        <h4 class="title-font d-inline-block">Company</h4>
                        <div class="d-flex justify-content-center">
                            <button class="cpu-select-button me-2" @click="setMotherboardType('Intel')">Intel</button>
                            <button class="cpu-select-button" @click="setMotherboardType('AMD')">AMD</button>
                        </div>
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
            let currentMotherboardType = await stockPartService.partCheckForMotherboard()
            let currentCpuType = await stockPartService.partCheckForCPU()
            if(type == 'cpu' && AppState.partCompany == 'Intel' && currentCpuType == 'Intel'){
                AppState.currentPartType = type
                let data = 'Intel'
                await stockPartService.getStockPartsCpu(data)
            }else if(type == 'cpu' && AppState.partCompany == 'AMD' && currentCpuType == 'AMD'){
                AppState.currentPartType = type
                let data = 'AMD'
                await stockPartService.getStockPartsCpu(data)
            }
            else if(type == 'motherB' && currentMotherboardType == 'Intel' && AppState.partCompany == 'Intel'){
                AppState.currentPartType = type
                let data = 'Intel'
                await stockPartService.getMotherBoards(data)
            }else if(type == 'motherB' && currentMotherboardType == 'AMD' && AppState.partCompany == 'AMD'){
                AppState.currentPartType = type
                let data = 'AMD'
                await stockPartService.getMotherBoards(data)
            }
            else{
                AppState.currentPartType = type
                await stockPartService.getStockParts(type)
            }
        }
        async function getBuildParts(){
            await pcPartService.getBuildParts(activeBuild.value.id)
        }
        async function setCpuType(type){
            AppState.partCompany = type
            getStockParts('cpu')
        }
        async function setMotherboardType(type){
            AppState.partCompany = type
            getStockParts('motherB')
        }

    return { 
        activeBuild,
        getStockParts,
        setCpuType,
        setMotherboardType,
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
@media screen and (min-width: 576px) {
    .part-holder{
    border-bottom: solid 2px purple;
    height: 120px;
    margin-top: 10px;
    padding-left: 8px;
    padding-right: 8px;
}
.info-box{
    outline: solid 2px purple;
    padding-bottom: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.322);
    border-radius: 8px;
    width: 50%;
}
.select-small{
    display: none;
}
}

@media screen and (max-width: 576px) {
    .part-holder{
    border-bottom: solid 2px purple;
    height: 140px;
    margin-top: 10px;
    padding-left: 8px;
    padding-right: 8px;
}
.info-box{
    outline: solid 2px purple;
    padding-bottom: 5px;
    box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.322);
    border-radius: 8px;
}
.select-large{
    display: none;
}
}
.title-font{
    border-bottom: solid 2px purple;
    font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
}
.box{
    outline: solid 2px purple;
    border-radius: 15px;
    overflow: hidden;
}
.pc-info{
    border-bottom: solid 1px purple;
}

.part-view{
    border-radius: 10px;
    box-shadow: 4px 4px 4px rgba(0, 0, 0, 0.288);
}

.cpu-select-button{
    all: unset;
    border: solid 2px purple;
    padding-left: 10px;
    padding-right: 10px;
    padding-top: 5px;
    padding-bottom: 5px;
}

.cpu-select-button:hover{
    all: unset;
    border: solid 2px purple;
    padding-left: 10px;
    padding-right: 10px;
    padding-top: 5px;
    padding-bottom: 5px;
    background-color: rgb(230, 230, 230);
    cursor: pointer;
}

.cpu-select-button:focus{
    all: unset;
    border: solid 2px purple;
    padding-left: 10px;
    padding-right: 10px;
    padding-top: 5px;
    padding-bottom: 5px;
    background-color: rgb(230, 230, 230);
    cursor: pointer;
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