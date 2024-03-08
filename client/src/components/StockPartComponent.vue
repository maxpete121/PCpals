<template>
    <div class="part-card d-flex align-items-center justify-content-between w-100">
        <div class="d-flex align-items-center">
            <img class="part-image" :src="stockPart.productImage" alt="Part image">
            <h5 class="ms-3">{{ stockPart.name }}</h5>
        </div>
        <div class="options-card me-3 d-flex align-items-center">
            <button class="option-button">View Details</button>
            <button class="option-button-two">Add Part</button>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { StockPart } from '../models/StockPart';
export default {
    props: {stockPart: {type: StockPart, required: true}},
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>
.part-card{
    outline: solid 1px purple;
}
.part-card:hover{
    outline: solid 1px purple;
    cursor: pointer;
    transform: scale(1.02);
}
.part-image{
    max-height: 70px;
    max-width: 170px;
    border-radius: 10px;
}
.options-card{
    outline: solid 1px white;
    border-radius: 15px;
    overflow: hidden;
}
.option-button{
    all: unset;
    border-right: solid 2px white;
    color: white;
    background-color: purple;
    padding-top: 4px;
    padding-bottom: 4px;
    padding-left: 9px;
    padding-right: 9px;
}
.option-button:hover{
    all: unset;
    border-right: solid 2px white;
    color: white;
    background-color: rgb(143, 0, 143);
    padding-top: 4px;
    padding-bottom: 4px;
    padding-left: 9px;
    padding-right: 9px;
}
.option-button-two{
    all: unset;
    color: white;
    background-color: purple;
    padding-top: 4px;
    padding-bottom: 4px;
    padding-left: 9px;
    padding-right: 9px;
}
.option-button-two:hover{
    all: unset;
    border-right: solid 2px white;
    color: white;
    background-color: rgb(143, 0, 143);
    padding-top: 4px;
    padding-bottom: 4px;
    padding-left: 9px;
    padding-right: 9px;
}
</style>