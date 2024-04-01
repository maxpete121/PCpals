<template>
  <nav class="navbar navbar-expand-sm navbar-dark px-3 new-nav">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center text-dark">
        <h3 class="fst-italic">BoisePcPals</h3>
      </div>
    </router-link>
    <router-link :to="{ name: 'Admin' }">
    <div>
      <h6>Admin Page</h6>
    </div>
     </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
          <router-link @click="getUserBuilds()" :to="{ name: 'myBuilds' }" class="btn text-success lighten-30 selectable text-uppercase">
            My Builds
          </router-link>
        </li>
        <li>
          <router-link :to="{ name: 'Clean' }" class="btn text-success lighten-30 selectable text-uppercase">
            PC Cleaning
          </router-link>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <div class="me-2">
        <button class="btn text-dark" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasCart" aria-controls="offcanvasCart">
          <i class="mdi mdi-cart fs-3"></i>
        </button>
      </div>
      <Login />
    </div>
  </nav>
  <CartOffCanvasComponent id="offcanvasCart"/>
</template>

<script>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import { pcBuildService } from '../services/PcBuildService.js';
import CartOffCanvasComponent from './CartOffCanvasComponent.vue';
export default {
  setup() {
    async function getUserBuilds(){
      await pcBuildService.getUserBuilds()
    }

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      getUserBuilds,
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      }
    }
  },
  components: { Login, CartOffCanvasComponent }
}
</script>

<style scoped>
.new-nav{
  border-bottom: solid 1px purple;
  box-shadow: 3px 3px 3px 3px rgba(0, 0, 0, 0.218);
}
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
