<template>
  <section class="container-fluid">
    <div class="row justify-content-center mt-3 mb-4 pb-2">
      <div class="col-lg-4 col-10 mt-3 info-card p-2 d-flex flex-column align-items-center">
        <h4>Welcome to your builds!</h4>
        <div class="d-flex flex-column align-items-center">
          <h5 class="mt-2">Create new build...</h5>
          <form @submit.prevent="createBuild()" class="mt-1" action="">
            <input v-model="buildRef" class="form-input" placeholder="Build name..." type="text" required>
            <button class="form-button">Create</button>
          </form>
        </div>
      </div>
    </div>
    <div class="row justify-content-center bg-dark pb-2 mt-4 pt-3 mt-3">
      <div class="col-lg-3 col-9 mt-3">
        <div class="d-flex filter-container justify-content-center">
          <button @click="getUserBuilds()" class="btn-one">Created Builds</button>
          <button @click="getSaveBuilds()" class="btn-two">Saved Builds</button>
        </div>
      </div>
    </div>
    <div class="row justify-content-center bg-dark pt-3 pb-3 build-container">
      <div class="col-lg-5 col-11 d-flex flex-column align-items-center ps-1 pe-1">
        <div v-if="userBuildType == 'created'" v-for="userBuild in userBuilds">
        <UserBuildComponent :userBuild="userBuild"/>
        </div>
        <div v-if="userBuildType == 'saved'" v-for="saveBuild in saveBuilds">
          <SaveBuildComponent :saveBuild="saveBuild"/>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { computed, onMounted, ref, watch } from 'vue';
import { Account } from '../models/Account';
import { AppState } from '../AppState';
import { pcBuildService } from '../services/PcBuildService';
import UserBuildComponent from '../components/UserBuildComponent.vue';
import SaveBuildComponent from '../components/SaveBuildComponent.vue'
import Pop from '../utils/Pop';
import { saveBuildService } from '../services/SaveBuildService';

export default {
  setup() {

    let buildRef = ref('')
    let account = computed(()=> AppState.account)
    watch(account, getUserBuilds)

    if(account.value.id){
      onMounted(()=>{
        getUserBuilds()
      })
    }
    
    async function createBuild(){
        let buildData = {name: buildRef.value, creatorId: account.value.id}
        let build = await pcBuildService.createBuild(buildData)
        buildRef.value = ''
        Pop.success(`${build.name} created!`)
    }
    async function getUserBuilds(){
      AppState.userBuildType = 'created'
      await pcBuildService.getUserBuilds()
    }
    async function getSaveBuilds(){
      AppState.userBuildType = 'saved'
      await saveBuildService.getSaveBuilds()
    }
    return {
      createBuild,
      buildRef,
      getUserBuilds,
      getSaveBuilds,
      userBuilds: computed(()=> AppState.userBuilds),
      userBuildType: computed(()=> AppState.userBuildType),
      saveBuilds: computed(()=> AppState.savedUserBuilds)
    }
  }, components: {UserBuildComponent, SaveBuildComponent}
}
</script>

<style scoped lang="scss">
@media screen and (min-width: 576px) {}

@media screen and (max-width: 576px) {}

.build-container{
  min-height: 430px;
}

.btn-one{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border-top: solid 1px white;
  border-bottom: solid 1px white;
  border-left: solid 1px white;
  border-top-left-radius: 15px;
  border-bottom-left-radius: 15px;
  color: white;
  background-color: purple;
}
.btn-two{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border: solid 1px white;
  border-top-right-radius: 15px;
  border-bottom-right-radius: 15px;
  color: white;
  background-color: purple;
}

.btn-one:hover{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border-top: solid 1px white;
  border-bottom: solid 1px white;
  border-left: solid 1px white;
  border-top-left-radius: 15px;
  border-bottom-left-radius: 15px;
  background-color: rgb(150, 0, 150);
  color: white;
  cursor: pointer;
}
.btn-two:hover{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border: solid 1px white;
  border-top-right-radius: 15px;
  border-bottom-right-radius: 15px;
  background-color: rgb(150, 0, 150);
  color: white;
  cursor: pointer;
}

.btn-one:focus{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border-top: solid 1px white;
  border-bottom: solid 1px white;
  border-left: solid 1px white;
  border-top-left-radius: 15px;
  border-bottom-left-radius: 15px;
  background-color: rgb(150, 0, 150);
  color: white;
}
.btn-two:focus{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border: solid 1px white;
  border-top-right-radius: 15px;
  border-bottom-right-radius: 15px;
  background-color: rgb(150, 0, 150);
  color: white;
}

.info-card{
  outline: solid 1px purple;
  border-radius: 10px;
}

.form-button{
  all: unset;
  border-bottom: solid 1px black;
  border-top: solid 1px black;
  border-right: solid 1px black;
  padding-top: 2px;
  padding-bottom: 2px;
  padding-left: 3px;
  padding-right: 3px;
  border-top-right-radius: 5px;
  border-bottom-right-radius: 5px;
}

.form-button:hover{
  all: unset;
  border-bottom: solid 1px black;
  border-top: solid 1px black;
  border-right: solid 1px black;
  padding-top: 2px;
  padding-bottom: 2px;
  padding-left: 3px;
  padding-right: 3px;
  cursor: pointer;
  color: darkblue;
  border-top-right-radius: 5px;
  border-bottom-right-radius: 5px;
}

.form-input{
  all: unset;
  outline: none !important;
  border-bottom: solid 1px black;
  border-top: solid 1px black;
  border-left: solid 1px black;
  padding-top: 2px;
  padding-bottom: 2px;
  padding-left: 4px;
  padding-right: 4px;
  border-top-left-radius: 5px;
  border-bottom-left-radius: 5px;
}

.form-input:focus{
  all: unset;
  outline: none !important;
  border-bottom: solid 1px black;
  border-top: solid 1px black;
  border-left: solid 1px black;
  padding-top: 2px;
  padding-bottom: 2px;
  padding-left: 4px;
  padding-right: 4px;
  border-top-left-radius: 5px;
  border-bottom-left-radius: 5px;
}
</style>
