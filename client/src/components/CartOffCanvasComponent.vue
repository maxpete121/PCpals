<template>
  <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasCart" aria-labelledby="offcanvasExampleLabel">
  <div class="offcanvas-header">
    <h5 class="offcanvas-title" id="offcanvasExampleLabel">Your Cart</h5>
    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
  </div>
  <div class="offcanvas-body">
    <div class="d-flex flex-column justify-content-between h-100">
      <div class="">
        <div v-for="cartItem in cartItems">
          <CartItemComponent :cartItem="cartItem"/>
        </div>
      </div>
      <div class="d-flex total">
        <h4>Total</h4>
      </div>
    </div>
  </div>
</div>
  </template>
  
  <script>
  import { computed } from 'vue'
import { AppState } from '../AppState';
import CartItemComponent from '../components/CartItemComponent.vue'
  export default {
    setup() {
      return {
        cartItems: computed(()=> AppState.cart)
      }
    }, components: {CartItemComponent}
  }
  </script>
  
  <style lang="scss" scoped>
.total{
  border-top: solid 1px purple;
}
</style>