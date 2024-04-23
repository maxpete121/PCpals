
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
                            <input  v-model="suggestionData.adminCode" type="text">
                        </div>
                        <div class="d-flex mt-2">
                            <label for="">AdminCode</label>
                            <input v-model="suggestionData.adminCode" type="text">
                        </div>
                        <div>
                            <button>Add Suggestion</button>
                        </div>
                    </form>
                </div>
                <div class="w-50">
                    <div v-for="build in builds"></div>
                </div>
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
export default {
    setup(){
        let suggestionData = ref()
        suggestionData.value = {}
        let stockPartData = ref()
        stockPartData.value = {}

        async function addStockPart(){
            console.log(stockPartData.value)
            await stockPartService.addStockPart(stockPartData.value)
            stockPartData.value = {}
        }
        async function createSuggestion(){
            await suggestionService.createSuggestion(suggestionData.value)
        }
    return { 
        builds: computed(()=> AppState.recentBuilds),
        stockPartData,
        addStockPart,
        suggestionData,
        createSuggestion
     }
    }
};
</script>


<style lang="scss" scoped>

</style>