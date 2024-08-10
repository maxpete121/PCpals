<template>
    <nav class="navbar navbar-expand-sm navbar-dark px-3 new-nav bg-dark ">
      <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
        <div class="d-flex flex-column align-items-center text-dark">
          <img class="logo" src="../assets/img/Logo.png" alt="PC pals logo">
        </div>
      </router-link>
      <router-link :to="{ name: 'Admin' }">
      <div v-if="adminVal == 'yes'">
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
            <router-link  :to="{ name: 'Browse' }" class="btn text-success lighten-30 selectable text-uppercase">
              Browse Builds
            </router-link>
          </li>
          <li v-if="account.id">
            <router-link @click="getUserBuilds()" :to="{ name: 'myBuilds' }" class="btn text-success lighten-30 selectable text-uppercase">
              My Builds
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'Clean' }" class="btn text-success lighten-30 selectable text-uppercase">
              PC Cleaning
            </router-link>
          </li>
          <li>
            <router-link :to="{ name: 'Contact' }" class="btn text-success lighten-30 selectable text-uppercase">
              Contact us!
            </router-link>
          </li>
        </ul>
        <!-- LOGIN COMPONENT HERE -->
        <div class="me-lg-3 mt-lg-0 mt-2 mb-lg-0 mb-1 sticky-top">
          <button @click="getCartItems()" class="cart-button sticky-top" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasCart" aria-controls="offcanvasCart">
            <i class="text-light mdi mdi-cart fs-3"></i>
          </button>
        </div>
        <Login />
      </div>
    </nav>
  <CartOffCanvasComponent id="offcanvasCart"/>
</template>

<script>
import { computed, onMounted, ref, watch } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import { pcBuildService } from '../services/PcBuildService.js';
import CartOffCanvasComponent from './CartOffCanvasComponent.vue';
import { cartItemService } from '../services/CartItemService';
import { AppState } from '../AppState';
import { accountService } from '../services/AccountService';
export default {
  setup() {
    let cart = computed(()=> AppState.cart)
    let useAccount = computed(()=> AppState.account)
    let adminVal = ref('')
    watch(cart, totalCart)
    watch(useAccount, adminTest)

    async function totalCart(){
      cartItemService.totalMath()
    }
    async function getCartItems(){
      await cartItemService.getCartItems()
    }
    async function getUserBuilds(){
      await pcBuildService.getUserBuilds()
    }

    async function adminTest(){
      let result = await accountService.adminTest(useAccount.value.id)
      if(result == true){ adminVal.value = 'yes'}
      else{adminVal.value = 'no'}
    }

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
      adminTest()
    })

    return {
      getUserBuilds,
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      },
      getCartItems,
      account: computed(()=> AppState.account),
      adminVal
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

.logo{
  margin-top: 3px;
  margin-bottom: 3px;
  max-height: 90px;
  max-width: 130px;
}

.cart-button{
  all: unset;
  border-radius: 50%;
  border: solid 1px black;
  outline: solid 1px white;
  padding-left: 10px;
  padding-right: 10px;
}

.cart-button:hover{
  all: unset;
  border-radius: 50%;
  border: solid 1px black;
  outline: solid 2px white;
  padding-left: 10px;
  padding-right: 10px;
  cursor: pointer;
}

.cart-button:focus{
  all: unset;
  border-radius: 50%;
  border: solid 1px black;
  outline: solid 2px white;
  padding-left: 10px;
  padding-right: 10px;
  cursor: pointer;
}

</style>
