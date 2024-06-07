<template>
  <section class="container-fluid">
    <div class="">
      <div>
        <h4>Your Items</h4>
      </div>
      <div></div>
    </div>
  </section>
  </template>
  
  <script>
  import { computed } from 'vue';
  import { AppState } from '../AppState';
  import AdminBuildComponent from '../components/AdminBuildComponent.vue';
  export default {
    setup() {
      return {
        cartItems: computed(() => AppState.cart),
        account: computed(() => AppState.account)
      }
    }, components: { AdminBuildComponent }
  }
  </script>
  
  <style scoped>
  img {
    max-width: 100px;
  }
  </style>