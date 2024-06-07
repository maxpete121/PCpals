<template>
  <section class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-4">
        <div class="text-center">
          <h4>Your Items</h4>
        </div>
        <div class="mt-3" v-for="cartItem in cartItems">
          <CartItemComponent :cartItem="cartItem"/>
        </div>
      </div>
      <div class="col-4">
        <form action="">
          <div>
            <div>
              <label for="">First name</label>
              <input type="text">
            </div>
            <div>
              <label for="">last</label>
              <input type="text">
            </div>
          </div>
          <div>
           <div>
             <label for="">Address</label>
             <input type="text">
           </div>
           <div>
             <label for="">Card Number</label>
             <input type="text">
           </div>
          </div>
        </form>
      </div>
    </div>
  </section>
  </template>
  
  <script>
  import { computed, onMounted, watch } from 'vue';
  import { AppState } from '../AppState';
  import AdminBuildComponent from '../components/AdminBuildComponent.vue';
  import CartItemComponent from '../components/CartItemComponent.vue'
import { cartItemService } from '../services/CartItemService';
  export default {
    setup() {
      let useAccount = computed(()=> AppState.account)
      onMounted(()=>{
        if(useAccount.value.id){
          cartItemService.getCartItems()
        }
        watch(useAccount, cartItemService.getCartItems)
      })
      return {
        cartItems: computed(() => AppState.cart),
        account: computed(() => AppState.account)
      }
    }, components: { AdminBuildComponent, CartItemComponent }
  }
  </script>
  
  <style scoped>
  img {
    max-width: 100px;
  }
  .title{
    border-bottom:solid 1px purple;
  }
  </style>