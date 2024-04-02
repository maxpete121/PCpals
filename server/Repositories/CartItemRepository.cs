namespace PCpals.Repositories;

public class CartItemRepository{
    private readonly IDbConnection db;
    public CartItemRepository(IDbConnection db){
        this.db = db;
    }

    internal CartItems CreateCartItem(CartItems cartItemData){
        string sql = @"
        INSERT INTO cartItems
        (buildId, creatorId)
        VALUES
        (@buildId, @creatorId);

        SELECT
        cartItems.*,
        pcBuilds.*
        FROM cartItems
        JOIN pcBuilds ON cartItems.buildId = pcBuilds.id
        WHERE cartItems.id = LAST_INSERT_ID()
        ";
        CartItems newCartItem = db.Query<CartItems, PcBuild, CartItems>(sql, (cartItem, pcBuild)=>{
            cartItem.Build = pcBuild;
            return cartItem;
        }, cartItemData).FirstOrDefault();
        return newCartItem;
    }
}