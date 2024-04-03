import { AppState } from "../AppState"
import { CartItems } from "../models/CartItems"
import { api } from "./AxiosService"



class CartItemService{
    async createCartItem(cartItemData){
        let response = await api.post('api/cartItems', cartItemData)
        let newItem = new CartItems(response.data)
        AppState.cart.unshift(newItem)
    }

    async getCartItems(){
        let response = await api.get('api/cartItems')
        let allCartItems = response.data.map(cart => new CartItems(cart))
        AppState.cart = allCartItems
        // console.log(allCartItems)
    }

    async deleteCartItem(cartItemId){
        let response = await api.delete(`api/cartItems/${cartItemId}`)
        let cartItemIndex = AppState.cart.findIndex(cart => cart.id == cartItemId)
        AppState.cart.splice(cartItemIndex, 1)
        return response.data
    }

    async totalMath(){}
}

export const cartItemService = new CartItemService()