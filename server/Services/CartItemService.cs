namespace PCpals.Services;

public class CartItemService{
    private readonly CartItemRepository repo;
    public CartItemService(CartItemRepository repo){
        this.repo = repo;
    }
    internal CartItems CreateCartItem(CartItems cartItemData){
        CartItems cartItem = repo.CreateCartItem(cartItemData);
        return cartItem;
    }
}