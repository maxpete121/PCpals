<template>
    <div class="container-fluid">
        <div class="row">
            <h4>{{ activeBuild.name }}</h4>
        </div>
        <div class="row"></div>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { pcBuildService } from '../services/PcBuildService';
export default {
    setup(){
        let route = useRoute()
        let activeBuild = computed(()=> AppState.activeBuildToEdit)
        async function getPcById(){
            await PcBuildService.getPcById(props.userBuild.id)
        }
    return { 
        activeBuild
     }
    }
};
</script>


<style lang="scss" scoped>

</style>