namespace PCpals.Controllers;

[ApiController]
[Route("api/cartItems")]

public class CartItemController : ControllerBase{
    private readonly Auth0Provider auth;
    private readonly CartItemService cartItemService;
    public CartItemController(Auth0Provider auth, CartItemService cartItemService){
        this.auth = auth;
        this.cartItemService = cartItemService;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CartItems>> CreateCartItem([FromBody]CartItems cartItemData){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            CartItems cartItems = cartItemService.CreateCartItem(cartItemData);
            return Ok(cartItems);
        }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
    }
}