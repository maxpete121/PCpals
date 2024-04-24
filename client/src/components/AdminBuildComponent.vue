<template>
  <div class="mt-2 bg-white">
    <div class="d-flex">
      <h3>Name:</h3>
      <h3 class="ms-4">{{ userBuild.name }}</h3>
    </div>
    <div class="d-flex">
      <h3>ID:</h3>
      <h3 class="ms-4">{{ userBuild.id }}</h3>
    </div>
    <div class="d-flex">
      <h3>User:</h3>
      <h3 class="ms-4">{{ userBuild.creator.name }}</h3>
    </div>
  </div>
  </template>
  
  <script>
  import { computed } from 'vue'
  import { AppState } from '../AppState'
  import { AuthService } from '../services/AuthService'
import { PcBuild } from '../models/PcBuild'
  export default {
    props: {userBuild: {type: PcBuild, required: true}},
    setup() {
      
      return {
      }
    }
  }
  </script>
  
  <style lang="scss" scoped></style>