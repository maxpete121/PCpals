
<template>
    <section class="container-fluid">
        <div class="row justify-content-center mt-2">
            <div class="col-4">
                <h4>Add Parts</h4>
                <form @submit.prevent="addStockPart()" class="d-flex flex-column w-25" action="">
                    <label for="">name</label>
                    <input v-model="stockPartData.name" type="text">
                    <label for="">product image</label>
                    <input v-model="stockPartData.productImage" type="text">
                    <label for="">type</label>
                    <input v-model="stockPartData.type" type="text">
                    <label for="">size</label>
                    <input v-model="stockPartData.size" type="text">
                    <label for="">price</label>
                    <input v-model="stockPartData.price" type="text">
                    <label for="">company</label>
                    <input v-model="stockPartData.company" type="text">
                    <label for="">speed</label>
                    <input v-model="stockPartData.speed" type="text">
                    <label for="">gigs</label>
                    <input v-model="stockPartData.gigs" type="text">
                    <label for="">powerScore</label>
                    <input v-model="stockPartData.powerScore" type="text">
                    <label for="">Watts</label>
                    <input v-model="stockPartData.watts" type="text">
                    <button class="mt-2">AddStockPart</button>
                </form>
            </div>
            <div class="col-5 d-flex">
                <div class="w-50">
                    <h4>Add Suggestion</h4>
                    <form @submit.prevent="createSuggestion()" action="">
                        <div class="d-flex">
                            <label for="">BuildID</label>
                            <input  v-model="suggestionData.buildId" type="text">    
                        </div>
                        <div class="d-flex mt-2">
                            <label for="">AdminCode</label>
                            <input v-model="suggestionData.adminCode" type="text">
                        </div>
                        <div class="mt-2 text-center">
                            <button>Add Suggestion</button>
                        </div>
                    </form>
                </div>
                <div class="w-50 user-builds bg-dark">
                    <h3 class="text-light">Builds to suggest</h3>
                    <div v-for="build in builds">
                        <AdminBuildComponent :userBuild="build"/>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-3 justify-content-center">
            <div class="col-5">
                <h3>Suggested Builds Posted</h3>
                <div v-for="suggestion in suggestions">
                    <SuggestedAdminBuild :suggestedBuild="suggestion"/>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-5">
                <h4>Support Tickets</h4>
            </div>
        </div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { StockPart } from '../models/StockPart';
import { stockPartService } from '../services/StockPartService.js';
import {suggestionService} from '../services/SuggestionService.js'
import AdminBuildComponent from '../components/AdminBuildComponent.vue';
import SuggestedAdminBuild from '../components/SuggestedAdminBuild.vue'
import { pcBuildService } from '../services/PcBuildService';
export default {
    setup(){
        let suggestionData = ref()
        suggestionData.value = {}
        let stockPartData = ref()
        stockPartData.value = {}
        onMounted(()=>{
            pcBuildService.getSharedBuilds()
            suggestionService.getSuggestions()
        })

        async function addStockPart(){
            console.log(stockPartData.value)
            await stockPartService.addStockPart(stockPartData.value)
            stockPartData.value = {}
        }
        async function createSuggestion(){
            await suggestionService.createSuggestion(suggestionData.value)
            suggestionData.value = {}
        }
    return { 
        suggestions: computed(()=> AppState.suggestedBuilds),
        builds: computed(()=> AppState.recentBuilds),
        stockPartData,
        addStockPart,
        suggestionData,
        createSuggestion
     }
    }, components: { AdminBuildComponent, SuggestedAdminBuild }
};
</script>


<style lang="scss" scoped>
.user-builds{
    max-height: 400px;
    overflow-y: scroll;
    border-radius: 10px;
    padding: 10px;
}
</style>