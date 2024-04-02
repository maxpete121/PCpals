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

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<CartItems>>> GetUserCartItems(){
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            List<CartItems> cartItems = cartItemService.GetUserCartItems(userInfo.Id);
            return Ok(cartItems);
        }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
    }

    [HttpGet("{cartItemId}")]
    public ActionResult<CartItems> GetCartItemById(int cartItemId){
        try
        {
            CartItems cartItems = cartItemService.GetCartItemById(cartItemId);
            return Ok(cartItems);
        }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
    }

    [HttpDelete("{cartItemId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteCartItem(int cartItemId){
        try
        {
             Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
             string message = cartItemService.DeleteCartItem(cartItemId, userInfo.Id);
             return Ok(message);
        }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
    }
}