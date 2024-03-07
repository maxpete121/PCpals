<template>
    <div class="component">
        <h4>{{ activeBuild.name }}</h4>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
export default {
    setup(){
        let route = useRoute()
        let activeBuild = computed(()=> AppState.activeBuildToEdit)
    return { 
        activeBuild
     }
    }
};
</script>


<style lang="scss" scoped>

</style>