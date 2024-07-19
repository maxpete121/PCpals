<template>
  <section class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-lg-4 d-flex flex-column align-items-center col-11 mt-3 me-lg-4">
        <div class="text-center">
          <h4>Your Items</h4>
        </div>
        <div class="text-center cart-items w-100 pt-1 pb-2">
          <h5 v-if="cartItems.length == 0">There are no items in your cart.</h5>
          <div class="mt-3" v-for="cartItem in cartItems">
            <CartItemComponent :cartItem="cartItem"/>
          </div>
          <div class="d-flex bg-light justify-content-between p-2 rounded-1">
            <h5>Build Fee</h5>
            <div class="d-flex">
              <h5>$100</h5>
              <h6 v-if="cartItems.length > 0">x</h6>
              <h6 v-if="cartItems.length > 0">{{ cartItems.length }}</h6>
            </div>
          </div>
        </div>
        <div class="cart-total d-flex justify-content-end pt-2 w-100">
          <h4 class="me-2">Total:</h4>
          <h4>${{ cartTotal }}</h4>
        </div>
      </div>
      <div class="col-lg-3 form-section col-11 mt-3 ms-lg-4">
        <form @submit.prevent="checkout()" action="">
          <div class="">
            <h4 class="mb-2 title pb-1">Name</h4>
            <div class="d-flex flex-column flex-lg-row align-items-baseline justify-content-evenly">
              <div class="d-flex flex-column me-3">
                <label for="">First</label>
                <input class="input-rework" type="text" required>
              </div>
              <div class="d-flex flex-column">
                <label for="">Last</label>
                <input class="input-rework" type="text" required>
              </div>
            </div>
          </div>
          <div>
            <h4 class="mb-2 mt-4 title pb-1">Card Info</h4>
            <div class="d-flex flex-column flex-lg-row justify-content-evenly">
             <div class="d-flex flex-column me-3">
               <label for="">Address</label>
               <input class="input-rework" type="text" required>
             </div>
             <div class="d-flex flex-column">
               <label for="">Address line 2 (Optional)</label>
               <input class="input-rework" type="text" required>
             </div>
            </div>
            <div class="d-flex flex-column flex-lg-row justify-content-evenly mt-3">
              <div class="d-flex flex-column me-3">
               <label for="">Card number</label>
               <input class="input-rework" type="text" required>
             </div>
             <div class="d-flex flex-column me-3">
               <label for="">Name on card</label>
               <input class="input-rework" type="text" required>
             </div>
            </div>
          </div>
          <div class="">
            <h4 class="mb-2 title pb-1 mt-4 pb-1">Shipping Address</h4>
            <div class="d-flex flex-column flex-lg-row align-items-baseline justify-content-evenly">
              <div class="d-flex flex-column me-3">
                <label for="">Address</label>
                <input class="input-rework" type="text" required>
              </div>
              <div class="d-flex flex-column me-3">
                <label for="">Apt, suite, unit, ect.</label>
                <input class="input-rework" type="text" required>
              </div>
            </div>
          </div>
          <div class="d-flex mt-4">
            <button class="me-2">Purchase</button>
            <button class="">Cancel</button>
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
import Pop from '../utils/Pop';
  export default {
    setup() {
      let useAccount = computed(()=> AppState.account)
      onMounted(()=>{
        if(useAccount.value.id){
          cartItemService.getCartItems()
        }
        watch(useAccount, cartItemService.getCartItems)

        })
          function checkout(){
            Pop.error('Feature not yet supported.')
          }
      return {
        checkout,
        cartItems: computed(() => AppState.cart),
        account: computed(() => AppState.account),
        cartTotal: computed(()=> AppState.totalCart)
      }
    }, components: { AdminBuildComponent, CartItemComponent }
  }
  </script>
  
  <style scoped>
    @media screen and (min-width: 576px) {
      .input-rework{
       all: unset;
       border: solid 1px purple;
       border-radius: 3px;
       width: 220px;
    }

    .cart-items{
      border-bottom: solid 1px purple;
      overflow-y: scroll;
      height: 400px;
    }
}

    @media screen and (max-width: 576px) {
      .input-rework{
       all: unset;
       border: solid 1px purple;
       border-radius: 3px;
       width: 220px;
    }

    .cart-items{
      border-bottom: solid 1px purple;
      overflow-y: scroll;
      height: 200px;
    }

    .form-section{
      display: flex;
      justify-content: center;
    }
}

  img {
    max-width: 100px;
  }
  .title{
    border-bottom:solid 1px purple;
  }
  .cart-total{
    border-bottom: solid 1px purple;
  }


  </style>