<template>
    <div class="build-card d-flex flex-column align-items-center p-1">
        <h3>{{ userBuild.name }}</h3>
        <div>
            <button class="me-2 btn-build">Add to Cart</button>
            <button class="ms-2 btn-build">Edit Build</button>
            <button><i class="mdi mdi-delete"></i></button>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { PcBuild } from '../models/PcBuild';
export default {
    props: {userBuild: {type: PcBuild, required: true}},
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>
.build-card{
    outline: solid 1px purple;
    box-shadow: 3px 3px 3px 2px rgba(0, 0, 0, 0.219);
}
.btn-build{
    all: unset;
    padding-top: 3px;
    padding-bottom: 3px;
    padding-right: 6px;
    padding-left: 6px;
    outline: solid 2px purple;
    border-radius: 2px;
}
</style>