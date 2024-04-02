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

    internal List<CartItems> GetUserCartItems(string userId){
        string sql = @"
        SELECT
        cartItems.*,
        pcBuilds.*
        FROM cartItems
        JOIN pcBuilds ON cartItems.buildId = pcBuilds.id
        WHERE cartItems.creatorId = @userId
        ";
        List<CartItems> cartItems = db.Query<CartItems, PcBuild, CartItems>(sql, (cartItem, pcBuild)=>{
            cartItem.Build = pcBuild;
            return cartItem;
        }, new{userId}).ToList();
        return cartItems;
    }

    internal CartItems GetCartItemById(int cartItemId){
        string sql = @"
        SELECT
        cartItems.*,
        pcBuilds.*
        FROM cartItems
        JOIN pcBuilds ON cartItems.buildId = pcBuilds.id
        WHERE cartItems.id = @cartItemId
        ";
        CartItems cartItem = db.Query<CartItems, PcBuild, CartItems>(sql, (cartItems, pcBuild)=>{
            cartItems.Build = pcBuild;
            return cartItems;
        }, new{cartItemId}).FirstOrDefault();
        return cartItem;
    }

    internal void DeleteCartItem(int cartItemId){
        string sql = @"
        DELETE FROM cartItems
        WHERE id = @cartItemId
        ";
        db.Execute(sql, new{cartItemId});
    }
}