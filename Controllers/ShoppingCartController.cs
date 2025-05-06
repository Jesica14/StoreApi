using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Data;
using StoreApi.Models;
using StoreApi.Services;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _cartService;

        public ShoppingCartController(IShoppingCartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{shoppingCartId}")]
        public ActionResult<IEnumerable<ShoppingCartItem>> GetCartItems(string shoppingCartId)
        {
            return Ok(_cartService.GetCartItems(shoppingCartId));
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] ShoppingCartRequest cartRequest)
        {
            if (cartRequest == null) return BadRequest("Invalid cart data.");

            var cartItem = new ShoppingCartItem
            {
                ProductId = cartRequest.ProductId,
                Quantity = cartRequest.Quantity,
                ShoppingCartId = cartRequest.ShoppingCartId
            };

            _cartService.AddToCart(cartItem);
            return CreatedAtAction(nameof(GetCartItems), new { shoppingCartId = cartRequest.ShoppingCartId }, cartItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCartItem(int id, [FromBody] ShoppingCartRequest cartRequest)
        {
            var existingItem = _cartService.GetCartItems(cartRequest.ShoppingCartId)
                                           .FirstOrDefault(i => i.ShoppingCartItemId == id);
            if (existingItem == null) return NotFound();

            existingItem.Quantity = cartRequest.Quantity;

            _cartService.UpdateCartItem(existingItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return NoContent();
        }

        [HttpGet("total/{shoppingCartId}")]
        public ActionResult<decimal> GetCartTotal(string shoppingCartId)
        {
            return Ok(_cartService.GetCartTotal(shoppingCartId));
        }
    }
}
