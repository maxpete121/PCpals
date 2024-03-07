<template>
  <section class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-4 mt-3 info-card p-2 d-flex flex-column align-items-center">
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
    <div class="row justify-content-center">
      <div class="col-3 mt-3">
        <div class="d-flex filter-container justify-content-center">
          <button class="btn-one">Your Builds</button>
          <button class="btn-two">Saved Builds</button>
        </div>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-4">
        <div v-for="userBuild in userBuilds">
        <UserBuildComponent :userBuild="userBuild"/>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { computed, ref, watch } from 'vue';
import { Account } from '../models/Account';
import { AppState } from '../AppState';
import { pcBuildService } from '../services/PcBuildService';
import UserBuildComponent from '../components/UserBuildComponent.vue';
import Pop from '../utils/Pop';

export default {
  setup() {
    let buildRef = ref('')
    let account = computed(()=> AppState.account)
    watch(account, getUserBuilds)
    
    async function createBuild(){
        let buildData = {name: buildRef.value, creatorId: account.value.id}
        let build = await pcBuildService.createBuild(buildData)
        buildRef.value = ''
        Pop.success(`${build.name} created!`)
    }
    async function getUserBuilds(){
      await pcBuildService.getUserBuilds()
    }
    return {
      createBuild,
      buildRef,
      userBuilds: computed(()=> AppState.userBuilds),
    }
  }, components: {UserBuildComponent}
}
</script>

<style scoped lang="scss">
.btn-one{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border-top: solid 1px purple;
  border-bottom: solid 1px purple;
  border-left: solid 1px purple;
  border-top-left-radius: 15px;
  border-bottom-left-radius: 15px;
}
.btn-two{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border: solid 1px purple;
  border-top-right-radius: 15px;
  border-bottom-right-radius: 15px;
}

.btn-one:hover{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border-top: solid 1px purple;
  border-bottom: solid 1px purple;
  border-left: solid 1px purple;
  border-top-left-radius: 15px;
  border-bottom-left-radius: 15px;
  background-color: rgb(215, 215, 215);
  cursor: pointer;
}
.btn-two:hover{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border: solid 1px purple;
  border-top-right-radius: 15px;
  border-bottom-right-radius: 15px;
  background-color: rgb(215, 215, 215);
  cursor: pointer;
}

.btn-one:focus{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border-top: solid 1px purple;
  border-bottom: solid 1px purple;
  border-left: solid 1px purple;
  border-top-left-radius: 15px;
  border-bottom-left-radius: 15px;
  background-color: rgb(215, 215, 215);
}
.btn-two:focus{
  all: unset;
  padding-top: 3px;
  padding-bottom: 3px;
  padding-left: 6px;
  padding-right: 6px;
  border: solid 1px purple;
  border-top-right-radius: 15px;
  border-bottom-right-radius: 15px;
  background-color: rgb(215, 215, 215);
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
