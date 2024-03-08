
<template>
    <div class="ms-2">
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
            <button class="mt-2">AddStockPart</button>
        </form>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { StockPart } from '../models/StockPart';
import { stockPartService } from '../services/StockPartService';
export default {
    setup(){
        
        let stockPartData = ref()
        stockPartData.value = {}

        async function addStockPart(){
            console.log(stockPartData.value)
            await stockPartService.addStockPart(stockPartData.value)
            stockPartData.value = {}
        }
    return { 
        stockPartData,
        addStockPart
     }
    }
};
</script>


<style lang="scss" scoped>

</style>