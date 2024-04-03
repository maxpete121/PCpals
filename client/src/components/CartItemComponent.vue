<template>
    <div class="cart-card d-flex justify-content-between pb-2">
        <div class="d-flex">
            <img class="cart-pic ms-1" :src="cartItem.build.casePicture" alt="Pc Picture">
            <h5 class="ms-3">{{ cartItem.build.name }}</h5>
        </div>
        <div class="d-flex">
            <div class="d-flex">
                <h5 class="text-success">${{ cartItem.build.price }}</h5>
            </div>
            <div class="ms-3">
                <button @click="deleteCartItem()" class="btn btn-outline-danger"><i class="mdi mdi-delete"></i></button>
            </div>
        </div>
    </div>
    </template>
    
    <script>
    import { computed } from 'vue'
    import {CartItems} from '../models/CartItems';
import { cartItemService } from '../services/CartItemService';
import Pop from '../utils/Pop';
    export default {
        props: {cartItem: {type: CartItems, required: true}},
      setup(props) {
        async function deleteCartItem(){
            if(window.confirm("Do you want to remove this item from cart?")){
                let message = await cartItemService.deleteCartItem(props.cartItem.id)
                Pop.success(`${message}`)
            }
        }
        return {
            deleteCartItem,
        }
      }
    }
    </script>
    
    <style lang="scss" scoped>
  .cart-card{
    border-bottom: solid 1px purple;
  }
  
  .cart-pic{
    max-height: 50px;
    max-width: 50px;
  }

  </style>