<template>
  <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasCart" aria-labelledby="offcanvasExampleLabel">
  <div class="offcanvas-header">
    <h5 class="offcanvas-title" id="offcanvasExampleLabel">Your Cart</h5>
    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
  </div>
  <div class="offcanvas-body">
    <div class="d-flex flex-column justify-content-between h-100">
      <div class="">
        <div class="mt-3" v-for="cartItem in cartItems">
          <CartItemComponent :cartItem="cartItem"/>
        </div>
        <div class="build-fee d-flex mt-3 pb-1 justify-content-between">
          <div class="d-flex">
            <img class="img-fee me-2" src="https://t3.ftcdn.net/jpg/02/54/36/80/360_F_254368041_H8DrzDQM98OZCKs7OFH14sehWQDvPY7W.jpg" alt="Build fee picture.">
            <h5>Build Fee</h5>
          </div>
          <div class="d-flex">
            <h5 class="text-success">$100</h5>
            <span v-if="cartLength > 1" class="d-flex align-items-baseline ms-3">
              <h6>X</h6>
              <h5>{{ cartLength }}</h5>
            </span>
          </div>
        </div>
      </div>
      <div class="d-flex justify-content-between total pt-2 align-items-center">
        <div class="d-flex">
          <h4>Total:</h4>
          <h4 class="text-success ms-3">${{ cartTotal }}</h4>
        </div>
        <div>
          <button v-if="account.id" @click="goToCheckout()" class="btn btn-success">Checkout</button>
          <button v-else @click="cartLogin()" class="btn btn-success">Login/Create Account</button>
        </div>
      </div>
    </div>
  </div>
</div>
  </template>
  
  <script>
  import { computed } from 'vue'
import { AppState } from '../AppState';
import CartItemComponent from '../components/CartItemComponent.vue'
import { router } from '../router';
import { Modal } from 'bootstrap';
import { Offcanvas } from 'bootstrap';
import {AuthService} from '../services/AuthService.js';
  export default {
    setup() {
      async function goToCheckout(){
        router.push({ path: '/Checkout'})
        Offcanvas.getOrCreateInstance('#offcanvasCart').hide()
      }

      async function cartLogin(){
        AuthService.loginWithPopup()
      }

      return {
        cartLogin,
        goToCheckout,
        cartTotal: computed(()=> AppState.totalCart),
        cartItems: computed(()=> AppState.cart),
        account: computed(()=> AppState.account),
        cartLength: computed(()=>{
          let count = AppState.cart.length
          return count
        })
      }
    }, components: {CartItemComponent}
  }
  </script>
  
  <style lang="scss" scoped>
.total{
  border-top: solid 1px purple;
}

.img-fee{
  height: 50px;
  width: 50px;
}

.build-fee{
  border-bottom: solid 1px  purple;
}
</style>