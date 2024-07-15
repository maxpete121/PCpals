<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <h6>Account page in development</h6>
  </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import AdminBuildComponent from '../components/AdminBuildComponent.vue';
export default {
  setup() {
    return {
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
