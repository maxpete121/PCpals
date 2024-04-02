import { AppState } from "../AppState"
import { CartItems } from "../models/CartItems"
import { api } from "./AxiosService"



class CartItemService{
    async createCartItem(cartItemData){
        let response = await api.post('api/cartItems', cartItemData)
        let newItem = new CartItems(response.data)
        AppState.cart.unshift(newItem)
    }
}

export const cartItemService = new CartItemService()