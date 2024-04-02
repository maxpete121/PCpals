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

    internal List<CartItems> GetUserCartItems(string userId){
        List<CartItems> cartItems = repo.GetUserCartItems(userId);
        return cartItems;
    }

    internal CartItems GetCartItemById(int cartItemId){
        CartItems cartItems = repo.GetCartItemById(cartItemId);
        return cartItems;
    }

    internal string DeleteCartItem(int cartItemId, string userId){
        CartItems cartItem = GetCartItemById(cartItemId);
        if(cartItem.CreatorId == userId){
            repo.DeleteCartItem(cartItemId);
            string message = "Item removed.";
            return message;
        }else{throw new Exception("Authorization ERROR");}
    }
}